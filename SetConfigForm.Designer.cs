
namespace PlayerDataBackupTool_CSharp
{
    partial class SetConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetConfigForm));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mongodb_uri = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mongodb_database = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mongodb_collection = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.world_playerdata_path = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uuid2name_path = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(635, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(304, 98);
            this.button1.TabIndex = 0;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "mongodb_uri    MongoDB数据库地址";
            // 
            // mongodb_uri
            // 
            this.mongodb_uri.Location = new System.Drawing.Point(19, 37);
            this.mongodb_uri.Name = "mongodb_uri";
            this.mongodb_uri.Size = new System.Drawing.Size(596, 28);
            this.mongodb_uri.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "mongodb_database    MongoDB数据库";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // mongodb_database
            // 
            this.mongodb_database.Location = new System.Drawing.Point(19, 103);
            this.mongodb_database.Name = "mongodb_database";
            this.mongodb_database.Size = new System.Drawing.Size(596, 28);
            this.mongodb_database.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "mongodb_collection    MongoDB集合";
            // 
            // mongodb_collection
            // 
            this.mongodb_collection.Location = new System.Drawing.Point(19, 174);
            this.mongodb_collection.Name = "mongodb_collection";
            this.mongodb_collection.Size = new System.Drawing.Size(596, 28);
            this.mongodb_collection.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(440, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "world_playerdata_path    玩家数据目录（以\\结尾）";
            // 
            // world_playerdata_path
            // 
            this.world_playerdata_path.Location = new System.Drawing.Point(19, 242);
            this.world_playerdata_path.Name = "world_playerdata_path";
            this.world_playerdata_path.Size = new System.Drawing.Size(596, 28);
            this.world_playerdata_path.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(332, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "uuid2name_path    uuid2name.json路径";
            // 
            // uuid2name_path
            // 
            this.uuid2name_path.Location = new System.Drawing.Point(19, 310);
            this.uuid2name_path.Name = "uuid2name_path";
            this.uuid2name_path.Size = new System.Drawing.Size(596, 28);
            this.uuid2name_path.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(635, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(304, 96);
            this.button2.TabIndex = 11;
            this.button2.Text = "重新解析UUID映射表 （正版）";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(632, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "0Sec,0Err";
            // 
            // SetConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 417);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.uuid2name_path);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.world_playerdata_path);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mongodb_collection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mongodb_database);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mongodb_uri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "填写配置文件";
            this.Load += new System.EventHandler(this.SetConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mongodb_uri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mongodb_database;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mongodb_collection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox world_playerdata_path;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uuid2name_path;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
    }
}