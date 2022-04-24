
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace PlayerDataBackupTool_CSharp
{
    public partial class Form1 : Form
    {
        MongoClient client = new MongoClient("mongodb://localhost:27017");

        public IMongoCollection<BsonDocument> getColl()
        {
            return client.GetDatabase("fifu_server").GetCollection<BsonDocument>("player_inv_data");
        }
        public Form1()
        {


            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getColl().Find(new BsonDocument()).ToList().ForEach(r =>
            {
                if (r.Contains("player_name"))
                    listPlayer.Items.Add(r.GetValue("player_name"));
            });

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<string> picPathList = new List<string>();
            //获取指定文件夹的所有文件
            string[] paths = Directory.GetFiles(@"D:\_Server\Paper-1.17.1\world\playerdata");
            foreach (var item in paths)
            {
                //获取文件后缀名
                if (Path.GetExtension(item).ToLower() == ".dat")
                {
                    string filename = Path.GetFileName(item);
                    string extension = Path.GetExtension(item);
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(item);

                    var pojo = new PlayerInvDataPojo();
                    pojo.player_uuid = fileNameWithoutExtension;
                    pojo.player_name = fileNameWithoutExtension;
                    //Console.WriteLine(fileNameWithoutExtension + $"\n{DateTime.Now.ToString()}\n" + FileToBase64Str(item));
                    pojo.data.Add(DateTime.Now.ToString(), FileToBase64Str(item));
                    getColl().InsertOne(pojo.ToBsonDocument());
                }
            }
            MessageBox.Show("备份完毕");

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

        public static T FromBson<T>(string base64data)
        {
            byte[] data = Convert.FromBase64String(base64data);

            using (MemoryStream ms = new MemoryStream(data))
            using (BsonDataReader reader = new BsonDataReader(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(reader);
            }
        }
    }
}
