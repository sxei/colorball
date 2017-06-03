namespace 彩色连珠
{
    partial class Form保存成绩
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
            this.label1 = new System.Windows.Forms.Label();
            this.button留名 = new System.Windows.Forms.Button();
            this.textBox姓名 = new System.Windows.Forms.TextBox();
            this.label成绩 = new System.Windows.Forms.Label();
            this.button分享到微博 = new System.Windows.Forms.Button();
            this.button放弃 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入您的大名：";
            // 
            // button留名
            // 
            this.button留名.Location = new System.Drawing.Point(16, 143);
            this.button留名.Name = "button留名";
            this.button留名.Size = new System.Drawing.Size(97, 45);
            this.button留名.TabIndex = 1;
            this.button留名.Text = "保存成绩";
            this.button留名.UseVisualStyleBackColor = true;
            this.button留名.Click += new System.EventHandler(this.button留名_Click);
            // 
            // textBox姓名
            // 
            this.textBox姓名.Font = new System.Drawing.Font("宋体", 16F);
            this.textBox姓名.Location = new System.Drawing.Point(16, 93);
            this.textBox姓名.Name = "textBox姓名";
            this.textBox姓名.Size = new System.Drawing.Size(341, 32);
            this.textBox姓名.TabIndex = 3;
            this.textBox姓名.Text = "匿名";
            // 
            // label成绩
            // 
            this.label成绩.AutoSize = true;
            this.label成绩.Location = new System.Drawing.Point(13, 23);
            this.label成绩.Name = "label成绩";
            this.label成绩.Size = new System.Drawing.Size(104, 16);
            this.label成绩.TabIndex = 4;
            this.label成绩.Text = "您的成绩为：";
            // 
            // button分享到微博
            // 
            this.button分享到微博.Image = global::彩色连珠.Properties.Resources.SinaWeibo_PNG;
            this.button分享到微博.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button分享到微博.Location = new System.Drawing.Point(129, 143);
            this.button分享到微博.Name = "button分享到微博";
            this.button分享到微博.Size = new System.Drawing.Size(133, 45);
            this.button分享到微博.TabIndex = 2;
            this.button分享到微博.Text = "分享到微博";
            this.button分享到微博.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button分享到微博.UseVisualStyleBackColor = true;
            this.button分享到微博.Click += new System.EventHandler(this.button分享到微博_Click);
            // 
            // button放弃
            // 
            this.button放弃.Location = new System.Drawing.Point(279, 143);
            this.button放弃.Name = "button放弃";
            this.button放弃.Size = new System.Drawing.Size(78, 45);
            this.button放弃.TabIndex = 5;
            this.button放弃.Text = "不保存";
            this.button放弃.UseVisualStyleBackColor = true;
            this.button放弃.Click += new System.EventHandler(this.button放弃_Click);
            // 
            // Form保存成绩
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 211);
            this.Controls.Add(this.button放弃);
            this.Controls.Add(this.label成绩);
            this.Controls.Add(this.textBox姓名);
            this.Controls.Add(this.button分享到微博);
            this.Controls.Add(this.button留名);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form保存成绩";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "游戏结束";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form保存成绩_FormClosed);
            this.Load += new System.EventHandler(this.Form保存成绩_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button留名;
        private System.Windows.Forms.Button button分享到微博;
        private System.Windows.Forms.TextBox textBox姓名;
        private System.Windows.Forms.Label label成绩;
        private System.Windows.Forms.Button button放弃;
    }
}