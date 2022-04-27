using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace PlayerDataBackupTool_CSharp
{
    public partial class SetConfigForm : Form
    {
        public SetConfigForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.cfg.mongodb_uri = mongodb_uri.Text;
            Form1.cfg.mongodb_database = mongodb_database.Text;
            Form1.cfg.mongodb_collection = mongodb_collection.Text;
            Form1.cfg.world_playerdata_path = world_playerdata_path.Text;
            Form1.cfg.uuid2name_path = uuid2name_path.Text;
            Form1.cfg.saveConfig();
            Form1.Singleton.feflashdate();
            this.Visible = false;
        }

        private void SetConfigForm_Load(object sender, EventArgs e)
        {
            mongodb_uri.Text = Form1.cfg.mongodb_uri;
            mongodb_database.Text = Form1.cfg.mongodb_database;
            mongodb_collection.Text = Form1.cfg.mongodb_collection;
            world_playerdata_path.Text = Form1.cfg.world_playerdata_path;
            uuid2name_path.Text = Form1.cfg.uuid2name_path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stats = (0, 0);
            string[] paths = Directory.GetFiles(Form1.cfg.world_playerdata_path);
            foreach (var item in paths)
            {
                if (Path.GetExtension(item).ToLower() == ".dat")
                {
                    runUnit(Path.GetFileNameWithoutExtension(item));
                }
            }
            label6.Text = $"{stats.Item1}Sec,{stats.Item2}Err,OK!";
        }

        //成功，失败
        (int, int) stats;
        private void runUnit(string uuid)
        {
            string jsonchuan = QueryPostparamsService("https://api.mojang.com/user/profile/" + uuid);
            //JObject jo = (JObject)JsonConvert.DeserializeObject(jsonchuan); //跟下方一行效果一样，两种写法，区别是什么我也不知道
            //把json转为这个JObject类型，并放在 jo 里

            try
            {
                JObject jo = JObject.Parse(jsonchuan);
                Form1.Singleton.dic.Add(uuid, jo["name"].ToString());
                File.WriteAllText(Form1.cfg.uuid2name_path, JsonConvert.SerializeObject(Form1.Singleton.dic,Formatting.Indented));
                stats.Item1++;
            }
            catch (Exception e)
            {
                stats.Item2++;
            }
            label6.Text = $"{stats.Item1}Sec,{stats.Item2}Err,Runing......";
        }

        //定义一个请求api并获取返回内容的方法，url作为参数方便测试不同url
        public static string QueryPostparamsService(string url)
        {
            //定义一个result用来存放接收到的json数据
            string result = "";
            //请求url
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //请求方法为Get
            req.Method = "Get";
            //这里没有添加请求头，注释掉了
            //req.Headers.Add()
            //使用try-catch捕获异常情况
            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                //获取内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
