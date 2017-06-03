namespace 彩色连珠
{
    partial class Form分享到新浪微博
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label提示 = new System.Windows.Forms.Label();
            this.button登录 = new System.Windows.Forms.Button();
            this.button取消 = new System.Windows.Forms.Button();
            this.pictureBox分享到微博 = new System.Windows.Forms.PictureBox();
            this.pictureBox发布图片 = new System.Windows.Forms.PictureBox();
            this.checkBox发布图片 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox分享到微博)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox发布图片)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 14F);
            this.textBox1.Location = new System.Drawing.Point(24, 66);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(445, 103);
            this.textBox1.TabIndex = 0;
            // 
            // label提示
            // 
            this.label提示.AutoSize = true;
            this.label提示.Font = new System.Drawing.Font("宋体", 14F);
            this.label提示.Location = new System.Drawing.Point(20, 29);
            this.label提示.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label提示.Name = "label提示";
            this.label提示.Size = new System.Drawing.Size(161, 19);
            this.label提示.TabIndex = 1;
            this.label提示.Text = "发布到新浪微博：";
            // 
            // button登录
            // 
            this.button登录.Location = new System.Drawing.Point(336, 207);
            this.button登录.Margin = new System.Windows.Forms.Padding(5);
            this.button登录.Name = "button登录";
            this.button登录.Size = new System.Drawing.Size(133, 46);
            this.button登录.TabIndex = 2;
            this.button登录.Text = "登录并授权";
            this.button登录.UseVisualStyleBackColor = true;
            this.button登录.Click += new System.EventHandler(this.button登录_Click);
            // 
            // button取消
            // 
            this.button取消.Location = new System.Drawing.Point(381, 273);
            this.button取消.Margin = new System.Windows.Forms.Padding(5);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(88, 46);
            this.button取消.TabIndex = 3;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            this.button取消.Click += new System.EventHandler(this.button取消_Click);
            // 
            // pictureBox分享到微博
            // 
            this.pictureBox分享到微博.Image = global::彩色连珠.Properties.Resources.分享到微博_32;
            this.pictureBox分享到微博.Location = new System.Drawing.Point(327, 16);
            this.pictureBox分享到微博.Name = "pictureBox分享到微博";
            this.pictureBox分享到微博.Size = new System.Drawing.Size(142, 32);
            this.pictureBox分享到微博.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox分享到微博.TabIndex = 4;
            this.pictureBox分享到微博.TabStop = false;
            // 
            // pictureBox发布图片
            // 
            this.pictureBox发布图片.Location = new System.Drawing.Point(24, 207);
            this.pictureBox发布图片.Name = "pictureBox发布图片";
            this.pictureBox发布图片.Size = new System.Drawing.Size(194, 121);
            this.pictureBox发布图片.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox发布图片.TabIndex = 5;
            this.pictureBox发布图片.TabStop = false;
            // 
            // checkBox发布图片
            // 
            this.checkBox发布图片.AutoSize = true;
            this.checkBox发布图片.Checked = true;
            this.checkBox发布图片.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox发布图片.Location = new System.Drawing.Point(24, 178);
            this.checkBox发布图片.Name = "checkBox发布图片";
            this.checkBox发布图片.Size = new System.Drawing.Size(123, 23);
            this.checkBox发布图片.TabIndex = 6;
            this.checkBox发布图片.Text = "是否带图片";
            this.checkBox发布图片.UseVisualStyleBackColor = true;
            this.checkBox发布图片.CheckedChanged += new System.EventHandler(this.checkBox发布图片_CheckedChanged);
            // 
            // Form分享到新浪微博
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 348);
            this.Controls.Add(this.checkBox发布图片);
            this.Controls.Add(this.pictureBox发布图片);
            this.Controls.Add(this.pictureBox分享到微博);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button登录);
            this.Controls.Add(this.label提示);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("宋体", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form分享到新浪微博";
            this.Text = "分享到新浪微博";
            this.Load += new System.EventHandler(this.Form分享到新浪微博_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox分享到微博)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox发布图片)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label提示;
        private System.Windows.Forms.Button button登录;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.PictureBox pictureBox分享到微博;
        private System.Windows.Forms.PictureBox pictureBox发布图片;
        private System.Windows.Forms.CheckBox checkBox发布图片;
    }
}