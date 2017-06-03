using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace 彩色连珠
{
    class SaveScore
    {
        public SaveScore()
        { }
        public const string scoreFile = "score.dat";// 保存成绩的文件名
        /// <summary>
        /// 保存成绩
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="score">成绩</param>
        public static void saveScore(string name, int score)
        {
            string file = Application.StartupPath + "\\" + scoreFile;
            FileStream fs;
            if (!File.Exists(file))  
                fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);//如果不存在，创建新文件 
            else
                fs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);//如果存在，直接打开文件 
            StreamReader sr = new StreamReader(fs);//从上面创建的fs流中读取
            List<string> names = new List<string> { };//姓名
            List<int> scores = new List<int> { };//分数
            List<string> times = new List<string> { };//时间
            string temp = "";
            try
            {
                while ((temp = sr.ReadLine()) != null)
                {
                    string[] t = SimplyDecrypt(temp).Split(':');
                    names.Add(t[0]);
                    scores.Add(Convert.ToInt32(t[1]));
                    times.Add(t[2]);
                }
            }
            catch { }
            sr.Close();
            int max = score;//假设传过来的score是最高分
            int i = 0;
            for (; i < scores.Count; i++)
                if (scores[i] < max)//一旦发现有比max小的数，跳出循环
                    break;
            scores.Insert(i, score);//在指定位置插入成绩、姓名和时间
            names.Insert(i, name);
            times.Insert(i, System.DateTime.Now.ToString("yyyy年MM月dd日HH时mm分"));
            StreamWriter sw = new StreamWriter(file);
            for (int j = 0; j < names.Count&&j<20; j++)//最多保存20组成绩
                sw.WriteLine(SimplyEncrypt(names[j] + ":" + scores[j] + ":" + times[j]));//写入文件
            sw.Close();
            
        }
        public static int redMax()//读取最高分
        {
            int max = 0;
            try
            {
                string file = Application.StartupPath + "\\" + scoreFile;
                if (File.Exists(file))
                {
                    StreamReader sr = new StreamReader(file);
                    max =Convert.ToInt32(SimplyDecrypt(sr.ReadLine()).Split(':')[1]);
                    sr.Close();
                }
            }
            catch { }
            return max;
        }
        public static string readScore()//读取所有成绩
        {
            string result = "成绩排行榜如下：\n";
            try
            {
                string file = Application.StartupPath + "\\" + scoreFile;
                int i = 0;//名次
                if (File.Exists(file))
                {
                    i = 1;//名次从1开始
                    string temp = "";
                    StreamReader sr = new StreamReader(file);
                    while ((temp = sr.ReadLine()) != null)
                    {
                        string[] t = SimplyDecrypt(temp).Split(':');
                        result += "第" + i + "名：" + t[0] + "，成绩：" + t[1] + "，时间：" + t[2] + "\n";
                        i++;
                    }
                    sr.Close();
                }
                if (i == 0||i==1)//如果没有成绩记录
                    result = "对不起，暂无任何成绩记录！";
            }
            catch{ }
            return result;
        }
        private const string Secret = "timizhuo"; // Secret的长度必须为8位！！
        private const string IV = "liuxianan";  // IV的长度必须在8位以上！

        private static string SimplyEncrypt(string rawContent)//加密
        {
            try
            {
                var des = new DESCryptoServiceProvider();
                var encryptor = des.CreateEncryptor(Encoding.ASCII.GetBytes(Secret), Encoding.ASCII.GetBytes(IV));
                var dataToEnc = Encoding.UTF8.GetBytes(rawContent);
                var resultStr = encryptor.TransformFinalBlock(dataToEnc, 0, dataToEnc.Length);
                return Convert.ToBase64String(resultStr);
            }
            catch { return ""; }
        }

        private static string SimplyDecrypt(string encryptedContent)//解密
        {
            try
            {
                var result = string.Empty;
                var des = new DESCryptoServiceProvider();
                var decryptor = des.CreateDecryptor(Encoding.ASCII.GetBytes(Secret), Encoding.ASCII.GetBytes(IV));
                var dataToDec = Convert.FromBase64String(encryptedContent);
                var resultBytes = decryptor.TransformFinalBlock(dataToDec, 0, dataToDec.Length);
                result = Encoding.UTF8.GetString(resultBytes);
                return result;
            }
            catch { return ""; }
        }
    }
}
