using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using AMicroblogAPI;
using System.IO;

namespace 彩色连珠
{
    public partial class Form分享到新浪微博 : Form
    {
        string content = "";
        public Form分享到新浪微博(string content)
        {
            InitializeComponent();
            this.content = content;
            textBox1.Text = this.content;
        }

        private void Form分享到新浪微博_Load(object sender, EventArgs e)
        {
            string appKey="2219505098";
            string appSecret="8bdfe757bd31be4e5a2c45d4d25b7a88";
            string redirectUri="https://api.weibo.com/oauth2/default.html";
            AMicroblogAPI.Environment.init(appKey, appSecret, redirectUri);
            pictureBox发布图片.Image = Image.FromFile("weiboTemp.png");
        }

        private void button取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button登录_Click(object sender, EventArgs e)
        {
            Form新浪微博授权页 form = new Form新浪微博授权页(content,checkBox发布图片.Checked);
            form.Show();
            var uri = AMicroblog.GetAuthorizationUri(AMicroblogAPI.Environment.RedirectUri, "code", null, "mobile") + "&forcelogin=true";
            Process.Start(uri);
            this.Close();
        }

        private void checkBox发布图片_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox发布图片.Checked)
                pictureBox发布图片.Visible = true;
            else
                pictureBox发布图片.Visible = false;
        }
    }
}
