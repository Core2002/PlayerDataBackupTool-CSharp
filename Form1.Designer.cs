﻿
namespace PlayerDataBackupTool_CSharp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listPlayer = new System.Windows.Forms.ListBox();
            this.listTime = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listPlayer
            // 
            this.listPlayer.FormattingEnabled = true;
            this.listPlayer.ItemHeight = 18;
            this.listPlayer.Location = new System.Drawing.Point(40, 26);
            this.listPlayer.Name = "listPlayer";
            this.listPlayer.Size = new System.Drawing.Size(566, 580);
            this.listPlayer.TabIndex = 0;
            this.listPlayer.SelectedIndexChanged += new System.EventHandler(this.listPlayer_SelectedIndexChanged);
            // 
            // listTime
            // 
            this.listTime.FormattingEnabled = true;
            this.listTime.ItemHeight = 18;
            this.listTime.Location = new System.Drawing.Point(612, 26);
            this.listTime.Name = "listTime";
            this.listTime.Size = new System.Drawing.Size(207, 580);
            this.listTime.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(825, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "一键备份";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(825, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "还原选中";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(825, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 59);
            this.button3.TabIndex = 4;
            this.button3.Text = "删库跑路";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(825, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 59);
            this.button4.TabIndex = 5;
            this.button4.Text = "刷新数据";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 612);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(316, 28);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 615);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "<- 请输入要查检索的玩家名";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 687);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listTime);
            this.Controls.Add(this.listPlayer);
            this.Name = "Form1";
            this.Text = "我的世界服务器玩家背包备份还原工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listPlayer;
        private System.Windows.Forms.ListBox listTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

