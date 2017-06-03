using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AMicroblogAPI;
using AMicroblogAPI.Common;
using AMicroblogAPI.DataContract;
using AMicroblogAPI.HttpRequests;
using System.IO;
namespace 彩色连珠
{
    public partial class Form新浪微博授权页 : Form
    {
        string accessToken = "";
        string content = "";
        bool containImage = true;
        public Form新浪微博授权页(string content,bool containImage)
        {
            InitializeComponent();
            this.content = content;
            this.containImage = containImage;
        }

        private void Form新浪微博授权页_Load(object sender, EventArgs e)
        {
            var uri = AMicroblog.GetAuthorizationUri(AMicroblogAPI.Environment.RedirectUri, "code", null, "mobile") + "&forcelogin=true";
            webBrowser1.Navigate(uri);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            try
            {
                var uri = e.Url;
                if (uri.AbsoluteUri.StartsWith(AMicroblogAPI.Environment.RedirectUri))//如果成功授权
                {
                    var authCode = uri.ToString().Split(new string[] { "?code=" }, StringSplitOptions.None)[1];
                    AMicroblogAPI.Environment.AccessToken = AMicroblog.GetAccessTokenByAuthorizationCode(authCode, AMicroblogAPI.Environment.RedirectUri);
                    accessToken=AMicroblogAPI.Environment.AccessToken.Token;
                    try
                    {
                        if (!containImage)//如果不带图片
                        {
                            AMicroblog.PostStatus(content);
                        }
                        else//如果带图片
                        {
                            var u = new UpdateStatusWithPicInfo();
                            u.Pic = "weiboTemp.png";
                            u.Status = content;
                            AMicroblog.PostStatusWithPic(u);
                        }
                        this.Close();
                        MessageBox.Show("分享到微博成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                    }
                    catch (Exception a) { MessageBox.Show("更新微博错误！原因如下：\n" + a.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message, "错误"); }
        }
    }
}
