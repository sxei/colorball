using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace 彩色连珠
{
    /// <summary>
    /// 保存游戏，以后再玩
    /// </summary>
    class SaveGame
    {
        public const string gameFile = "saveGame.dat";// 保存棋盘的文件名
        public static bool save(Color[,] ball, int[] nextColor,int score,int m)
        {
            bool flag = false;
            string file = Application.StartupPath + "\\" + gameFile;
            if (File.Exists(file))
                File.Delete(file);
            StreamWriter sw = new StreamWriter(file);
            for (int i = 0; i < m; i++)
            {
                string temp = "";
                for (int j = 0; j < m; j++)
                    temp += ball[i, j].ToString().Substring(7).Replace("]", "") + ",";
                temp = temp.Substring(0, temp.Length - 1);
                sw.WriteLine(temp);//写入文件
            }
            sw.WriteLine(nextColor[0]+","+nextColor[1]+","+nextColor[2]);
            sw.WriteLine(score);
            sw.Close();
            flag = true;
            return flag;
        }
        public static void read(Form主窗口 f)
        {
            string file = Application.StartupPath + "\\" + gameFile;
            if (File.Exists(file))
            {
                if(MessageBox.Show("检测到您上次保存了游戏，是否继续上次的游戏？","询问",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    int m = Form主窗口.m;
                    FileStream fs= new FileStream(file, FileMode.Open, FileAccess.Read);//如果存在，直接打开文件 
                    StreamReader sr = new StreamReader(fs);//从上面创建的fs流中读取
                    string temp="";
                    int i = 0;
                    while((temp=sr.ReadLine())!=null)
                    {
                        if (i < m)
                        {
                            string[] ball = temp.Split(',');
                            for (int j = 0; j < m; j++)
                            {
                                Color c = Color.FromName(ball[j]);
                                if (c == f.panel游戏区.BackColor)
                                    f.clearBall(i, j);
                                else
                                    f.drawBall(i, j, c);
                            }
                        }
                        else if (i == m)
                        {
                            string[] nextColor = temp.Split(',');
                            for (int k = 0; k < 3; k++)
                                f.drawBall(k, Convert.ToInt32(nextColor[k]));
                        }
                        else if (i == m + 1)
                            f.label分数.Text = "分数：" + temp;
                        i++;
                    }
                    sr.Close();
                    File.Delete(file);//加载完毕后删除该文件
                }
            }
        }
    }
}
