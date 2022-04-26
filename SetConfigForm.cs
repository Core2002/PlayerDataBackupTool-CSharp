using System;
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
    }
}
