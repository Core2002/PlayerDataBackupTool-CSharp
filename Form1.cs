
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace PlayerDataBackupTool_CSharp
{
    public partial class Form1 : Form
    {
        MongoClient client;
        public static ConfigPojo cfg;
        public static Form1 Singleton;
        public static SetConfigForm setConfigForm;
        Dictionary<string, string> dic;

        public IMongoCollection<BsonDocument> getColl()
        {
            return client.GetDatabase(cfg.mongodb_database).GetCollection<BsonDocument>(cfg.mongodb_collection);
        }
        public Form1()
        {
            Singleton = this;
            setConfigForm = new SetConfigForm();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            feflashdate();
        }

        private void listPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            listTime.Items.Clear();
            if (listPlayer.SelectedItem == null)
                return;
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var res = getColl().Find(new BsonDocument("player_name", listPlayer.SelectedItem.ToString())).FirstOrDefault();
            var json = JObject.Parse(res.ToJson(jsonWriterSettings)).ToString();

            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerInvDataPojo>(json);
            foreach (var a in data.data.Keys)
                listTime.Items.Add(a);
            var k = listPlayer.SelectedItem.ToString();
            if (dic.ContainsKey(k))
            {
                label2.Text = $"> {dic[k]}";
                listPlayer.Text = k;
                return;
            }
            else
            {
                textBox1.Text = "";
                label2.Text = ">";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!feflashdate())
                return;
            
            string[] paths = Directory.GetFiles(cfg.world_playerdata_path);
            foreach (var item in paths)
            {
                if (Path.GetExtension(item).ToLower() == ".dat")
                {
                    string filename = Path.GetFileName(item);
                    string extension = Path.GetExtension(item);
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(item);

                    var res = getColl().Find(new BsonDocument("player_uuid", fileNameWithoutExtension));
                    if (res.Count() > 0)
                    {
                        var r = FromBson<PlayerInvDataPojo>(res.FirstOrDefault().ToBson());
                        r.data.Add(DateTime.Now.ToString(), FileToBase64Str(item));
                        getColl().FindOneAndUpdate(new BsonDocument("player_uuid", r.player_uuid), r.ToBsonDocument());
                    }
                    else
                    {
                        var pojo = new PlayerInvDataPojo();
                        pojo.player_uuid = fileNameWithoutExtension;
                        pojo.player_name = fileNameWithoutExtension;
                        pojo.data.Add(DateTime.Now.ToString(), FileToBase64Str(item));
                        getColl().InsertOne(pojo.ToBsonDocument());
                    }

                }
            }
            if (!feflashdate())
                return;

            MessageBox.Show("备份完毕", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 文件转为base64编码
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string FileToBase64Str(string filePath)
        {
            string base64Str = string.Empty;
            try
            {
                using (FileStream filestream = new FileStream(filePath, FileMode.Open))
                {
                    byte[] bt = new byte[filestream.Length];

                    //调用read读取方法
                    filestream.Read(bt, 0, bt.Length);
                    base64Str = Convert.ToBase64String(bt);
                    filestream.Close();
                }

                return base64Str;
            }
            catch (Exception)
            {
                return base64Str;
            }
        }

        /// <summary>
        /// 文件base64解码
        /// </summary>
        /// <param name="base64Str">文件base64编码</param>
        /// <param name="outPath">生成文件路径</param>
        public void Base64ToOriFile(string base64Str, string outPath)
        {
            var contents = Convert.FromBase64String(base64Str);
            using (var fs = new FileStream(outPath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(contents, 0, contents.Length);
                fs.Flush();
            }
        }

        public static string ToBson<T>(T value)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BsonDataWriter datawriter = new BsonDataWriter(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(datawriter, value);
                return Convert.ToBase64String(ms.ToArray());
            }

        }

        public static T FromBson<T>(byte[] data)
        {
            //byte[] data = Convert.FromBase64String(base64data);

            using (MemoryStream ms = new MemoryStream(data))
            using (BsonDataReader reader = new BsonDataReader(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(reader);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var i = listTime.SelectedItem;
            if (i == null)
            {
                MessageBox.Show("你需要选择要还原的时间点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var uuid = listPlayer.SelectedItem.ToString();
            var time = i.ToString();
            var res = getColl().Find(new BsonDocument("player_uuid", uuid));
            if (res.Count() > 0)
            {
                var r = FromBson<PlayerInvDataPojo>(res.FirstOrDefault().ToBson());
                string base64data;
                if (r.data.TryGetValue(time, out base64data))
                {
                    var path = cfg.world_playerdata_path + uuid + ".dat";
                    Base64ToOriFile(base64data, path);
                    string name = "[未知玩家]";
                    if (dic.ContainsKey(uuid))
                    {
                        name = dic[uuid];
                    }
                    MessageBox.Show($"玩家{name}，UUID:{uuid}\r\n还原到 {time} 成功\r\n路径：{path}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("还原失败->数据损坏", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("还原失败->玩家数据未备份", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            feflashdate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!feflashdate())
                return;

            if ((int)MessageBox.Show("确定需要删库跑路吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == 1)
            {
                if ((int)MessageBox.Show("确定需要删库跑路吗？", "警告（确认2/3）", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == 1)
                {
                    if ((int)MessageBox.Show("确定需要删库跑路吗？", "警告（确认3/3）", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == 1)
                    {
                        getColl().DeleteMany(new BsonDocument());
                        feflashdate();
                        MessageBox.Show("数据已删除", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            feflashdate();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            refalshsearch();
        }

        public void refalshsearch()
        {
            foreach (var k in dic.Keys)
            {
                if (dic.ContainsValue(textBox1.Text) && textBox1.Text.Equals(dic[k]))
                {
                    label1.Text = $"[{dic[k]}]({k})";
                    listPlayer.Text = k;
                    return;
                }
                else
                {
                    label1.Text = "查无此人";
                }

            }
        }

        public bool feflashdate()
        {
            try
            {
                cfg = Path2Pojo<ConfigPojo>(@"config.json");
                client = new MongoClient(cfg.mongodb_uri);
                listPlayer.Items.Clear();
                getColl().Find(new BsonDocument()).ToList().ForEach(r =>
                {
                    if (r.Contains("player_name"))
                        listPlayer.Items.Add(r.GetValue("player_name"));
                });
                string text = File.ReadAllText(cfg.uuid2name_path);
                object obj = Newtonsoft.Json.JsonConvert.DeserializeObject(text);
                JObject js = obj as JObject;
                dic = js.ToObject<Dictionary<string, string>>();
                listTime.Items.Clear();

                if (listPlayer.SelectedItem == null)
                {
                    label2.Text = ">";
                    textBox1.Text = "";
                    return true;
                }
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                var res = getColl().Find(new BsonDocument("player_name", listPlayer.SelectedItem.ToString())).FirstOrDefault();
                var json = JObject.Parse(res.ToJson(jsonWriterSettings)).ToString();

                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerInvDataPojo>(json);
                foreach (var a in data.data.Keys)
                    listTime.Items.Add(a);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "配置填写错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!setConfigForm.Visible)
                {
                    setConfigForm.ShowDialog();
                    return false;
                }
            }
            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            refalshsearch();
        }

        public T Path2Pojo<T>(string path)
        {
            return new JavaScriptSerializer().Deserialize<T>(File.ReadAllText(path));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (!setConfigForm.Visible)
            {
                setConfigForm.ShowDialog();
            }
        }
    }
}
