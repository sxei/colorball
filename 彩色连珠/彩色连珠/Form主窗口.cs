using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Collections;
using 彩色连珠.Properties;
using System.Media;
using WMPLib;
namespace 彩色连珠
{
    public partial class Form主窗口 : Form
    {
        public Form主窗口()
        { 
            InitializeComponent();//初始化
        }
        public int successLength = 5;//成功时至少需要多少个球在一条线上，例如为5时表示五子成龙


        public static int m = 10;//方格的行数与列数
        public Color[,] ball= new Color[m, m];//一个二维数组，用来存放整个棋盘每个位置的颜色信息
        public Color[,] temp_ball=new Color[m,m];//用于悔棋
        public Color[] color = { Color.Red,Color.Green,Color.Blue,Color.Brown,Color.Yellow,Color.LightBlue,Color.Violet,Color.White,Color.Black,Color.DarkOrange};//所有球可能的颜色值
        //public string[] color = { "红色","绿色","蓝色","褐色","黄色","浅蓝色","紫色","白色","黑色","深橘色"};
        public int move_i=-1, move_j=-1;//用来存放即将移动的球的行和列
        public int[][] path;//用来存放每次查找成功后的路径信息
        public int path_idx=2;//path路径信息的索引，之所以要从2开始，是因为第0个是长度，第1个存放的是起点坐标
        public int score = 0;//分数
        public int dx = 5;//仅用在对球进行缩放时记录缩放的程度，默认设为5
        public bool isFirstRun = true;//判断游戏是否为第一次运行的标志，当第一次运行时，在Paint事件中随机出5个球
        public int[] nextColor = new int[3];//下一组颜色信息

        WMPLib.WindowsMediaPlayer wmp = new WindowsMediaPlayer();//播放音频的wmp控件，需先在项目属性的引用的COM里面添加名为Windows Media Player、路径为C:\Windows\System32\wmp.dll引用!

        int lastOverI = -1;//上次鼠标移过的行,用于绘制鼠标移过方格时的动态效果
        int lastOverJ = -1;//上次鼠标移过的列

        //用于悔棋，记录上次移动的球的原始位置与新位置,1、2为原始位置的行和列，3、4位新位置的行和列
        public int[] last_move = new int []{-1,-1,-1,-1 };

        System.Resources.ResourceManager manager = new System.Resources.ResourceManager("彩色连珠.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
        //上面一句话是实例化一个ResourceManager，这里一定要注意baseName的写法，为：命名空间+文件夹名+资源文件名（不带后缀名），不知道怎么写的可以到“Resources.Designer.cs”这个文件里去找
        //用这个写法的目的是为了方便根据资源文件名来查找，如果不需要查找的画则比较简单，如下：
        //首先添加以下引用：using 彩色连珠.Properties;然后直接写：Resources.Red就可以获取资源文件了。
        
        
        private void Form主窗口_Load(object sender, EventArgs e)
        {
            label提示.Text = successLength+"个相同颜色的球在一起会消掉，同时加10分，"+(successLength+1)+"个球加20分，"+(successLength+2)+"个球30分，依次类推，但棋盘越满，难度越大。";
            startGame();//开始游戏
            readMaxScore();//读取最大分数
            
        }

        /// <summary>
        /// 播放声音的方法
        /// </summary>
        /// <param name="url">音频文件的路径</param>
        private void playAudio(string url)
        {
            //UnmanagedMemoryStream audio=(UnmanagedMemoryStream)manager.GetObject(url);
            wmp.URL = url;
            wmp.controls.play();
        }

        //游戏区的重绘事件，这个事件的作用主要有2个：一个是让游戏第一次运行时画方格线
        //以及随机出5个子（这些代码不能放在Form_Loaded事件里，因为窗体第一次生成会触发
        //Paint事件进而覆盖原图）,第二个作用是解决当窗体最小化或改变大小时绘图区一片空
        //白的问题，解决的思路就是方格线和球全部重绘。
        //用“Bitmap bit= new Bitmap(x,y);Graphics g=Graphics.FromImage(bit);”的方法
        //不会出现最小化变空白的现象，但每次画完图后都必须刷新，因此闪屏现象严重。
        private void panel游戏区_Paint(object sender, PaintEventArgs e)
        {
            drawLine();//画方格线
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                    if (ball[i, j] != panel游戏区.BackColor)
                    {
                        drawBall(i,j,ball[i,j]); //如果该位置的颜色不是背景色（即没有球）则按照指定颜色画球
                    }
            makeNextColor();//防止窗口最小化后还原一片空白
            if (isFirstRun)//如果是第一次运行
            {
                for (int i = 0; i < 5; i++)
                    drawBallRandom();//随机出5个球
                makeNextColor();
                isFirstRun = false;
                SaveGame.read(this);
            }
        }
        /// <summary>
        /// 开始游戏的准备工作
        /// </summary>
        private void startGame()
        {
            panel游戏区.BackColor = Color.LightGray;//首次运行，给游戏区填充灰色背景色
            Graphics g = panel游戏区.CreateGraphics();
            g.Clear(panel游戏区.BackColor);//用背景色清空
            drawLine();//画方格线
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                    ball[i, j] = panel游戏区.BackColor;//将ball数组全部用背景色来标记
            score = 0;
            label分数.Text = "分数：0";//分数置0
        }
        private void drawLine()//画方格线的函数
        {
            Graphics g = panel游戏区.CreateGraphics();
            for (int i = 0; i < m; i++)
            {
                g.DrawLine(new Pen(Color.Black), 0, panel游戏区.Height / m * i, panel游戏区.Width, panel游戏区.Height / m * i);
                g.DrawLine(new Pen(Color.Black), panel游戏区.Width / m * i, 0, panel游戏区.Width / m * i, panel游戏区.Height);
            }
        }
        /// <summary>
        /// 画球的函数
        /// </summary>
        /// <param name="i">行数</param>
        /// <param name="j">列数</param>
        /// <param name="color">要画的球的颜色</param>
        /// <param name="dx">指定球比方格要小的像素个数</param>
        private void drawBall(int i, int j, Color color,int dx)
        {
            //关于图片：如果直接将这些不同颜色的球的图片放在程序根目录文件夹来操作比较简单，
            //但是缺点就是老是要跟一个文件夹，不方便，所以将所有图片放入程序的资源文件
            //至于怎样调用程序的资源文件，查找了很多资料后终于得到解决，具体方法看下面的代码。
            Graphics g = panel游戏区.CreateGraphics();
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;//高质量显示图片
            int x = panel游戏区.Width / m, y = panel游戏区.Height / m;//x，y分别为单个方块宽和高
            string temp = color.ToString().Substring(7).Replace("]", "");//color的颜色值转换为字符串后形如：color[Red]，本句代码执行后的结果为Red
            //string picturePath = Application.StartupPath + @"\球\" + temp + ".png";//到程序目录中查找指定颜色球的路径，如：C:\Documents and Settings\Administrator\桌面\刘显安\彩色连珠\bin\Debug\球\Red.png
            g.DrawImage((Bitmap)manager.GetObject(temp), x * j + dx, y * i + dx, x - dx - dx, y - dx - dx);//将图片画在游戏区
            ball[i, j] = color;//同时更新ball数组
            //g.FillEllipse(new SolidBrush(color),x*j+5,y*i+5,x-10,y-10);//如果是直接用系统函数画圆的画就用这句话 
        }
        public void drawBall(int i, int j, Color color)//重载上面的函数，将dx默认为5
        {
            drawBall(i,j,color,5);
        }
        /// <summary>
        /// 在下一组提示区画指定颜色的球
        /// </summary>
        /// <param name="i">位置索引，因为每次出3个球，所以i只可能是0、1、2三种情况</param>
        /// <param name="colorIdx">颜色索引，实际上就是要画的球的颜色信息</param>
        public void drawBall(int i,  int colorIdx)
        {
            Graphics g = pictureBox下一组.CreateGraphics();
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;//高质量显示图片
            string temp = color[colorIdx].ToString().Substring(7).Replace("]", "");//color的颜色值转换为字符串后形如：color[Red]，本句代码执行后的结果为Red
            System.Resources.ResourceManager manager = new System.Resources.ResourceManager("彩色连珠.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            g.DrawImage((Bitmap)manager.GetObject(temp), i * 55 + 10, 3, 50, 50);//将图片画在下一组的地方
        }
        /// <summary>
        /// 用背景色填充指定方格，以达到清除的目的
        /// </summary>
        /// <param name="i">行</param>
        /// <param name="j">列</param>
        public void clearBall(int i,int j)
        {
            Graphics g = panel游戏区.CreateGraphics();
            int x = panel游戏区.Width / m, y = panel游戏区.Height / m;
            g.FillRectangle(new SolidBrush(panel游戏区.BackColor), x * j + 2, y * i + 2, x - 4, y - 4);
            ball[i, j]= panel游戏区.BackColor;
        }
        /// <summary>
        /// 游戏开始时随机出球，位置随机，颜色也随机（用于没有下一组提示的时候）
        /// </summary>
        private void drawBallRandom()
        {
            if (!checkOver())
            {
                Random random = new Random();
                bool flag = true;
                while (flag)
                {
                    int i = random.Next(0, 10);
                    int j = random.Next(0, 10);
                    if (ball[i, j] == panel游戏区.BackColor)
                    {
                        flag = false;
                        int c = random.Next(0, color.Length);
                        //MessageBox.Show(i + "," + j + ":" + color[c].ToString());
                        drawBall(i, j, color[c]);
                        checkSuccess(i, j);//出子后要判断是否有可以消的球
                    }
                }
            }
        }
        /// <summary>
        /// 随机在某个位置画指定颜色的球，位置随机，颜色不随机
        /// </summary>
        /// <param name="colorIdx">颜色索引</param>
        private void drawBallRandom(int colorIdx)
        {
            if (!checkOver())
            {
                Random random = new Random();
                bool flag = true;
                while (flag)
                {
                    int i = random.Next(0, 10);
                    int j = random.Next(0, 10);
                    if (ball[i, j] == panel游戏区.BackColor)
                    {
                        flag = false;
                        drawBall(i, j, color[colorIdx]);
                        checkSuccess(i, j);
                    }
                }
            }
        }
        /// <summary>
        /// 产生下一组随机球
        /// </summary>
        private void makeNextColor()
        {
            Graphics g = pictureBox下一组.CreateGraphics();
            g.Clear(pictureBox下一组.BackColor);
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                nextColor[i] = random.Next(0,color.Length);
                drawBall(i,nextColor[i]);//绘制在下一组提示的地方
            }
        }
        /// <summary>
        /// 检查游戏是否结束
        /// </summary>
        /// <returns>返回真假</returns>
        private bool checkOver()
        {
            bool isFull = true;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                {
                    if (ball[i, j] == panel游戏区.BackColor)
                        isFull = false;
                }
            return isFull;
        }

        private void panel游戏区_MouseClick(object sender, MouseEventArgs e)//游戏区的鼠标单击事件
        {
            timer缩放.Enabled = false;//结束球的缩放
            int x = panel游戏区.Width / m, y = panel游戏区.Height / m;
            if (ball[e.Y / y, e.X / x] != panel游戏区.BackColor)//如果单击的是球
            {
                //单击球播放声音
                playAudio("MoveStart.wav");
                dx = 5;//让dx恢复到默认值
                if(move_i>=0)
                    drawBall(move_i, move_j, ball[move_i, move_j], dx);
                //在新的球缩放时将上次点的球（如果有）重置为默认大小（因为球动态变换大
                //小，所以停止缩放时可能不是默认大小，这句话是重新画一个默认大小的球）

                move_i = e.Y / y;
                move_j = e.X / x;
                timer缩放.Enabled = true;//让单击过的球开始动态变换大小
            }
            else if (move_i >= 0 && move_j >= 0)//如果单击的是空白处，且有一个即将移动的球
            {
                bool[,] isHaveBall = new bool[m, m];//保存棋盘上每个位置是否有球的信息
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < m; j++)
                    {
                        if (ball[i, j] == panel游戏区.BackColor)
                            isHaveBall[i, j] = false;
                        else
                            isHaveBall[i, j] = true;
                    }
                int end_i = e.Y / y, end_j = e.X / x;//目标行与列
                Search s = new Search(isHaveBall, m, move_i, move_j, end_i, end_j);//实例化一个查找类
                path = s.start();//开始查找
                if (path[0][0] != 0)//如果查找成功
                {
                    for (int i = 0; i < m;i++ )
                        for(int j=0;j< m;j++)
                             temp_ball[i,j] = ball[i,j];//  保存当前棋盘信息，注意绝对不能直接把ball赋值给temp_ball，因为其引用同一个对象
                    

                    path_idx = 2;//path数组第一组数据是长度，第二组数据是起点，所以要从第三组数据开始
                    timer移动.Enabled = true;
                    //string t = "";   //下面注释的代码用来查看文本形式的路径信息，仅供程序员调试看，玩家不需要管
                    //for (int i = 1; i <= path[0][0]; i++)
                    //{
                    //    t += path[i][0] + "," + path[i][1] + "  ";
                    //}
                    // MessageBox.Show(t);
                }
                else 
                {
                    playAudio("MoveError.wav");//不能移动时播放错误声音 
                }
            }
        }
        private void timer移动_Tick(object sender, EventArgs e)//这部分代码是为了实现球的动态移动位置效果
        {
            //注意：这里一定要注意要用上一个点的颜色来填充，而不是起始点的颜色，
            //因为每画完一个点之后，它的颜色已经被填充为背景色了
            drawBall(path[path_idx][0], path[path_idx][1], ball[path[path_idx - 1][0], path[path_idx - 1][1]]);//在指定位置画指定颜色的球
            clearBall(path[path_idx - 1][0], path[path_idx - 1][1]);//画过的方格要清空
            path_idx++;
            if (path_idx > path[0][0])
            {
                playAudio("MoveSuccess.wav");//移动成功播放声音
                timer移动.Enabled = false;
                move_i = move_j = -1;//把将要移动的球的位置置为-1
                if (!checkSuccess(path[path_idx - 1][0], path[path_idx - 1][1]))//如果新移动一个球后没有五子连线的，再随机出3个球
                {
                    button悔棋.Enabled = true;//设置能够悔棋
                    for (int i = 0; i < 3 && !checkOver(); i++)//当游戏没有结束时随机出3个球
                        drawBallRandom(nextColor[i]);
                    if (checkOver())
                    {
                        button悔棋.Enabled = false;//游戏结束时不能悔棋
                        button以后再玩.Enabled = false;//游戏结束时不能保存游戏

                        Form保存成绩 f = new Form保存成绩(score, this);
                        f.ShowDialog();
                    }
                    makeNextColor();
                }
                else
                    button悔棋.Enabled = false;//消球后不能悔棋
            }
        }
        private int[] countSameBall(int h,int lie,int dir)//计算相同颜色球的个数和位置
        {
            int i = 1, j = 1, sum = 1;
            if (dir == 0)//从左往右
            {
                //从当前位置开始，行不变列在变，往左，如果左边的球颜色和当前球的颜色一致或者是白色，那么继续
                for (i = 1; lie - i >= 0 && (ball[h, lie - i] == ball[h, lie] || ball[h, lie - i] == Color.White); i++)//往左
                    sum++;
                for (j = 1; lie + j < m && (ball[h, lie + j] == ball[h, lie] || ball[h, lie + j] == Color.White); j++)//往右
                    sum++;
            }
            else if (dir == 1)//从上往下
            {
                for (i = 1; h - i >= 0 && (ball[h - i, lie] == ball[h, lie] || ball[h - i, lie] == Color.White); i++)//往上
                    sum++;
                for (j = 1; h + j < m && (ball[h + j, lie] == ball[h, lie] || ball[h + j, lie] == Color.White); j++)//往下
                    sum++;
            }
            else if (dir == 2)//从左上往右下
            {
                for (i = 1; h - i >= 0 && lie - i >= 0 && (ball[h - i, lie - i] == ball[h, lie] || ball[h - i, lie - i] == Color.White); i++)//往左上
                    sum++;
                for (j = 1; h + j < m && lie + j < m && (ball[h + j, lie + j] == ball[h, lie] || ball[h + j, lie + j] == Color.White); j++)//往右下
                    sum++;
            }
            else if (dir == 3)//从左下往右上
            {
                for (i = 1; h + i < m && lie - i >= 0 && (ball[h + i, lie - i] == ball[h, lie] || ball[h + i, lie - i] == Color.White); i++)//往左下
                    sum++;
                for (j = 1; h - j >= 0 && lie + j < m && (ball[h - j, lie + j] == ball[h, lie] || ball[h - j, lie + j] == Color.White); j++)//往右上
                    sum++;
            }
            int[] res;
            if (sum >= successLength)
                res = new int[] { sum, i - 1, j - 1 ,h,lie};//从左往右,第一个数存放sum的值，后面2个数分别存放左和右的索引，最后2个数存放行号和列号
            else
                res = new int[] { 0 };
            return res;
        }
        private int[] countWhite(int h,int lie,int dir)
        {
            Color temp1 = Color.White;
            Color temp2 = Color.White;
            int i=1, j=1;
            int[] res,res1=new int[]{},res2=new int[]{};
            if (dir == 0)//从左往右
            {
                for (i = 1; lie - i >= 0 && ball[h, lie - i] != panel游戏区.BackColor; i++)//往左
                {
                    if (ball[h, lie - i] != Color.White)//找到第一个不是白色的球的颜色
                    {
                        temp1 = ball[h, lie - i]; i++; break;
                    }
                }
                for (j = 1; lie + j < m && ball[h, lie + j] != panel游戏区.BackColor; j++)//往右
                {
                    if (ball[h, lie + j] != Color.White)
                    {
                        temp2 = ball[h, lie + j]; j++; break;
                    }
                }
                res1 = countSameBall(h, lie - i + 1, dir);
                res2 = countSameBall(h, lie + j - 1, dir);
            }
            else if (dir == 1)
            {
                for (i = 1; h-i >= 0 && ball[h-i, lie] != panel游戏区.BackColor; i++)//往左
                {
                    if (ball[h-i, lie] != Color.White)//找到第一个不是白色的球的颜色
                    {
                        temp1 = ball[h - i, lie]; i++; break;
                    }
                }
                for (j = 1; h + j < m && ball[h+j, lie] != panel游戏区.BackColor; j++)//往右
                {
                    if (ball[h + j, lie] != Color.White)
                    {
                        temp2 = ball[h + j, lie]; j++; break;
                    }
                }
                res1 = countSameBall(h-i+1, lie,dir);
                res2 = countSameBall(h+j-1, lie,dir);
            }
            else if (dir == 2)
            {
                for (i = 1;h - i >= 0 && lie - i >= 0 && ball[h - i, lie - i] != panel游戏区.BackColor; i++)//往左
                {
                    if (ball[h - i, lie - i] != Color.White)//找到第一个不是白色的球的颜色
                    {
                        temp1 = ball[h - i, lie - i]; i++; break;
                    }
                }
                for (j = 1; h + j < m &&lie+j<m&& ball[h + j, lie+j] != panel游戏区.BackColor; j++)//往右
                {
                    if (ball[h + j, lie+j] != Color.White)
                    {
                        temp2 = ball[h + j, lie+j]; j++; break;
                    }
                }
                res1 = countSameBall(h - i + 1, lie-i+1, dir);
                res2 = countSameBall(h + j - 1, lie+j-1, dir);
            }
            else if (dir == 3)
            {
                for (i = 1; h + i < m && lie - i >= 0 && ball[h + i, lie - i] != panel游戏区.BackColor; i++)//往左
                {
                    if (ball[h + i, lie - i] != Color.White)//找到第一个不是白色的球的颜色
                    {
                        temp1 = ball[h + i, lie - i]; i++; break;
                    }
                }
                for (j = 1; h - j >=0 && lie + j < m && ball[h - j, lie + j] != panel游戏区.BackColor; j++)//往右
                {
                    if (ball[h - j, lie + j] != Color.White)
                    {
                        temp2 = ball[h - j, lie + j]; j++; break;
                    }
                }
                res1 = countSameBall(h + i - 1, lie - i + 1, dir);
                res2 = countSameBall(h - j + 1, lie + j - 1, dir);
            }
            res = res1;
            if (temp1 == Color.White || res1[0] == 0)//
                res = res2;
            else if (res1[0] != 0 && res2[0] != 0&&temp1!=temp2)
                res = new int[] { res1[0] + res2[0] - 4, res1[1] + i - 1, res2[2] + j - 1, h, lie };
            return res;    
        }
        /// <summary>
        /// 检查是否有5个颜色相同的球连在一起
        /// </summary>
        /// <param name="h">起始查找位置的行</param>
        /// <param name="lie">起始查找位置的列，为什么不用字母“l”呢？因为和数字“1”长得太像了！（汗）</param>
        /// <returns>检查的结果</returns>
        private bool checkSuccess(int h,int lie)
        {
            bool f = false;//标记是否成功消球
            int[][] res = new int[4][];//4行N列的二维数组，每一行用来存放一个方向检查的结果

            if (ball[h, lie] != Color.White)//如果刚下的球不是白色
            {
                for (int k = 0; k < 4;k++ )
                    res[k] = countSameBall(h, lie, k);
            }
            else  //如果刚下的球是白色
            {
                for (int k = 0; k < 4; k++)
                    res[k] = countWhite(h, lie, k);
            }
            
            for (int p = 0; p < 4;p++ )
            {
                if (res[p][0] !=0)//如果有球需要消去
                {
                    int temp_h = res[p][3], temp_lie = res[p][4];
                    for (int q = -res[p][1]; q <=  res[p][2]; q++)
                    {
                        switch (p)
                        {
                            case 0: clearBall(temp_h, temp_lie + q); break;
                            case 1: clearBall(temp_h + q, temp_lie); break;
                            case 2: clearBall(temp_h + q, temp_lie + q); break;
                            case 3: clearBall(temp_h - q, temp_lie + q); break;
                        }
                    }
                    score += 10*(res[p][0]-successLength+1);//5个棋子加10分，6个棋子加20分，依次类推
                    label分数.Text = "分数："+score;//分数加上去
                    f = true;
                    playAudio("GetScore.wav");//如果消了球播放成功声音
                }
            }
            return f;
        }
        
        bool isGrow = false;//真表示球变大，假表示球变小
        private void timer缩放_Tick(object sender, EventArgs e)//这个计时器仅用来实现点击某一个球后动态变换大小的效果
        {
            if (ball[move_i, move_j] == panel游戏区.BackColor)//如果要移动的球不存在那么停止缩放
            {
                //这3行代码很重要，可以解决点击某个球后直接点击“重新开始”或“悔棋”时出现的错误
                timer缩放.Enabled = false;
                move_i = -1;
                move_j = -1;
            }
            else
            {
                //注意：dx是表示球的起始坐标离方格的距离，所以dx越大表示球越小
                if (dx >= 12)
                    isGrow = true;//球变到最小后，让它开始变大
                if (dx <= 5)
                    isGrow = false;//球变到最大后，让它开始变小
                if (isGrow)
                    dx -= 2;//让球变大一点
                else
                    dx += 2;//让球变小一点
                Color temp = ball[move_i, move_j];
                clearBall(move_i, move_j);//先清空
                ball[move_i, move_j] = temp;
                drawBall(move_i, move_j, temp, dx);//然后重新画球
            }
            
        }

        public void button开始_Click(object sender, EventArgs e)
        {
            startGame();
            for (int i = 0; i < 5; i++)
                drawBallRandom();//随机出5个球
            makeNextColor();
            button悔棋.Enabled = false;
            button以后再玩.Enabled = true;
        }
        
        public void readMaxScore()//读取最高分
        {
            int max = SaveScore.redMax();
            label最高分.Text = "最高分："+max;
        }

        private void 重新开始ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            button开始_Click(null, null);
        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 查看成绩ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(SaveScore.readScore(), "成绩排行榜", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 帮助ToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("如有问题，请至新浪微博@刘显安（http://weibo.com/liuxianan）\n或者联系QQ：937925941！", "帮助", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 关于ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("游戏名称：彩色连珠 v1.4\n作者：刘显安\n微博：http://weibo.com/liuxianan\nQQ：937925941\n2013年2月20日", "彩色连珠", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void 分享到新浪微博ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bit=new Bitmap(this.Width,this.Height);//实例化一个和窗体一样大的bitmap
            Graphics g=Graphics.FromImage(bit);
            g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
            g.CopyFromScreen(this.Left,this.Top,0,0,new Size(this.Width,this.Height));//保存整个窗体为图片
            //g.CopyFromScreen(panel游戏区 .PointToScreen(Point.Empty), Point.Empty, panel游戏区.Size);//只保存游戏区
            bit.Save("weiboTemp.png");//默认保存格式为PNG，保存成jpg格式质量不是很好
            Form分享到新浪微博 form = new Form分享到新浪微博("我正在玩#彩色连珠#小游戏，得了"+score+"分，非常好玩哦，你也来玩一下吧……");
            form.Show();
        }
        
        private void panel游戏区_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = panel游戏区.CreateGraphics();
            int x = panel游戏区.Width / m, y = panel游戏区.Height / m;
            int i = e.Y / y;//当前行
            int j = e.X / x;//当前列
            if (i != lastOverI || j != lastOverJ)//如果鼠标移动到了一个新的方格
            {
                if (lastOverI >= 0 && lastOverJ >= 0)//将上次鼠标移动过的方格的红色标记去除
                {
                    g.DrawRectangle(new Pen(panel游戏区.BackColor, 2), x * lastOverJ + 2, y * lastOverI + 2, x - 4, y - 4);
                }
                g.DrawRectangle(new Pen(Color.Red, 2), x * j + 2, y * i + 2, x - 4, y - 4);//在当前方格处绘制红色标记
                lastOverI = i;//当前行赋值给上次的行
                lastOverJ = j;
            }
        }

        private void button悔棋_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("悔一次棋将会扣除10分，是否要继续？","友情提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (score < 10)
                    MessageBox.Show("您的分数不足10分，不能够悔棋！");
                else 
                {
                    //以下2行代码是为解决“当点击某个新出现的球后直接点击悔棋程序错误”的Bug。2013年2月19日
                    //分析：每次点击新出现的球后，“timer_缩放”还是true，悔棋后那个位置肯定是空白，
                    //所以这时候如果仍然对空白位置缩放肯定会出错，因为此时是用背景色进行画球
                    //而点击不是新出现的球时，悔棋后那个位置的球还在，只不过悔棋后那个球还在不停的缩放而已

                    //再次更新：由于已经在“timer_缩放”中加了下面2行代码，所以这里可以注释掉。2013年2月20日
                    //timer缩放.Enabled = false;//结束球的缩放，不管当前是否有球在缩放都要结束掉
                    // move_i = move_j = -1;//把将要移动的球的位置置为-1，因为悔棋后肯定没有球被点击


                    score -= 10;//每次悔棋扣除10分
                    label分数.Text = "分数：" + score;//分数减去10分
                    for (int i = 0; i < m; i++)
                        for (int j = 0; j < m; j++)
                        {
                            if (temp_ball[i, j] == panel游戏区.BackColor)
                                clearBall(i, j);
                            else
                                drawBall(i, j, temp_ball[i, j]);
                        }
                    makeNextColor();
                    button悔棋.Enabled = false;
                }
            }
            
        }

        private void button以后再玩_Click(object sender, EventArgs e)
        {
            if (SaveGame.save(ball, nextColor, score, m))
                if (MessageBox.Show("恭喜！保存游戏状态成功！\n\n是否退出游戏？", "成功", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Application.Exit();
                else
                    MessageBox.Show("由于未知原因，保存游戏失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
