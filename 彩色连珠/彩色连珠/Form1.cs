using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
namespace 彩色连珠
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        int x = 10;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.panel1.BackgroundImage = Image.FromFile(@"F:\我的图片\我的图片\2008-08\7a57ba2b9ea496ebe7cd4060.jpg");
                Graphics g = panel1.CreateGraphics();
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;//高质量显示图片;
             System.Resources.ResourceManager manager = new System.Resources.ResourceManager("彩色连珠.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            //上面一句话是实例化一个ResourceManager，这里一定要注意baseName的写法，为：命名空间+文件夹名+资源文件名（不带后缀名），不知道怎么写的可以到“Resources.Designer.cs”这个文件里去找
            //用这个写法的目的是为了方便根据资源文件名来查找，如果不需要查找的画则比较简单，如下：
            //首先添加以下引用：using 彩色连珠.Properties;然后直接写：Resources.Red就可以获取资源文件了。
            g.DrawImage((Bitmap)manager.GetObject("Red"), ++x, 50);//将图片画在游戏区
            Thread.Sleep(40);
        }

    }
}
