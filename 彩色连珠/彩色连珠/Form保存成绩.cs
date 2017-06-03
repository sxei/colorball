using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 彩色连珠
{
    public partial class Form保存成绩 : Form
    {
        public int score;
        Form主窗口 f;
        public Form保存成绩(int score,Form主窗口 f)
        {
            InitializeComponent();
            this.score = score;
            this.f = f;
            textBox姓名.Focus();//姓名文本框设置焦点
        }

        private void Form保存成绩_Load(object sender, EventArgs e)
        {
            label成绩.Text = "您的成绩为："+score+"分";
        }

        private void button留名_Click(object sender, EventArgs e)
        {
            SaveScore.saveScore(textBox姓名.Text,score);//保存成绩到文件
            f.readMaxScore();//读取最高分
            this.Close();
        }

        private void button分享到微博_Click(object sender, EventArgs e)
        {
            f.分享到新浪微博ToolStripMenuItem_Click(null, null);
        }

        private void button放弃_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form保存成绩_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("是否要重新开始？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                f.button开始_Click(null,null);//触发主窗体的“重新开始”按钮
        }
        
    }
}
