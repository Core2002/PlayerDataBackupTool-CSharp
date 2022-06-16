using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
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

        int pathsNumber = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            stats = (0, 0);
            pathsNumber = 0;
            string[] paths = Directory.GetFiles(Form1.cfg.world_playerdata_path);
            foreach (var item in paths)
            {
                if (Path.GetExtension(item).ToLower() == ".dat")
                {
                    pathsNumber++;
                    runUnit(Path.GetFileNameWithoutExtension(item));
                }
            }
        }

        //成功，失败
        (int, int) stats;
        private async void runUnit(string uuid)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(10);
                string jsonchuan = await client.GetStringAsync("https://api.mojang.com/user/profile/" + uuid);
                JObject jo = JObject.Parse(jsonchuan);
                Form1.Singleton.dic.Add(uuid, jo["name"].ToString());
                File.WriteAllText(Form1.cfg.uuid2name_path, JsonConvert.SerializeObject(Form1.Singleton.dic,Formatting.Indented));
                stats.Item1++;
            }
            catch (Exception)
            {
                stats.Item2++;
            }
            if(pathsNumber == stats.Item1 + stats.Item2)
            {
                label6.Text = $"{stats.Item1}Sec,{stats.Item2}Err,OK";
                button2.Enabled = true;
            }
            else
            {
                label6.Text = $"{stats.Item1}Sec,{stats.Item2}Err,Runing......{pathsNumber}";
            }
            
        }

    }
}
