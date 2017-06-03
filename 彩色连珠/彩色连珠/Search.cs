using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace 彩色连珠
{
    class Search//查找函数
    {
        bool[,] ball;//一个二维数组，记录每行每列是否有球
        int m, start_i, start_j, end_i, end_j;//分别表示行数（或列数），需要移动的球的行及列，目标位置的行及列
        /// <summary>
        /// 查找方法的构造函数
        /// </summary>
        /// <param name="ball">存放每个游戏方格上是否有球的bool二维数组</param>
        /// <param name="m">方格的行数（或列数）</param>
        /// <param name="start_i">需要移动的球的行</param>
        /// <param name="start_j">需要移动的球的列</param>
        /// <param name="end_i">目标位置的行</param>
        /// <param name="end_j">目标位置的列</param>
        public Search(bool[,] ball, int m, int start_i, int start_j, int end_i, int end_j)
        {
            this.ball = ball;
            this.m = m;
            this.start_i = start_i;
            this.start_j = start_j;
            this.end_i = end_i;
            this.end_j = end_j;
        }
        class Open  //Open表
        {
            public Open(int child_i, int child_j, int parent_i, int parent_j)
            {
                this.child_i = child_i;
                this.child_j = child_j;
                this.parent_i = parent_i;
                this.parent_j = parent_j;
            }
            public int child_i;
            public int child_j;
            public int parent_i;
            public int parent_j;
        }
        class Closed:Open  //Closed表，继承自Open表，只多了一个id号
        {
            public Closed(int id, Open o)
                :base(o.child_i,o.child_j,o.parent_i,o.parent_j)
            {
                this.id = id;
            }
            public int id;
        }
        class Queue//队列
        {
            const int maxsize = 1000;
            Open[] queue = new Open[maxsize];
            int front;
            int rear;
            public void iniQueue()//初始化
            {
                this.front = this.rear = 0;
            }
            public void add(Open x)//进栈
            {
                if ((this.rear + 1) % maxsize != this.front)
                {
                    this.rear = (this.rear + 1) % maxsize;
                    this.queue[this.rear] = x;
                }
            }
            public Open delete()//出栈
            {
                Open o = this.queue[(this.front + 1) % maxsize];
                if (this.rear != this.front)
                    this.front = (this.front + 1) % maxsize;
                return o;
            }
            public bool isEmpty()//判断是否为空
            {
                if (this.front == this.rear)
                    return true;
                else
                    return false;
            }
        }
        public int[][] start()//开始查找
        {
            int[][] result=new int[1000][];//记录结果的二维数组，如果查找失败,第一组数据放入（0,0），否则放入（1,1），从第二组数据开始存放数据
            int n = 0;//记录Closed表中的个数
            Queue q = new Queue();//实例化一个Open表的队列Queue
            q.iniQueue();
            Closed[] c = new Closed[100000];
            q.add(new Open(start_i, start_j, -1, -1));//因第一个点不存在父节点，故用-1来表示NULL
            bool flag = false;//判断是否退出while循环的标志
            while (!flag)
            {
                if (q.isEmpty())//如果堆栈为空，退出循环
                    flag = true;
                else
                {
                    Open temp = q.delete();//从Open表取出队头元素
                    //MessageBox.Show(temp.child_i + "," + temp.child_j);
                    c[n] = new Closed(n, temp);
                    if (c[n].child_i == end_i && c[n].child_j == end_j)
                        flag = true;
                    else//按照左上右下的顺序查找
                    {
                        if (c[n].child_j - 1 >= 0 && !ball[c[n].child_i, c[n].child_j - 1])//左
                        { q.add(new Open(c[n].child_i, c[n].child_j - 1, c[n].child_i, c[n].child_j)); ball[c[n].child_i, c[n].child_j - 1]=true; }
                        if (c[n].child_i - 1 >= 0 && !ball[c[n].child_i - 1, c[n].child_j])//上
                        { q.add(new Open(c[n].child_i - 1, c[n].child_j, c[n].child_i, c[n].child_j));ball[c[n].child_i - 1, c[n].child_j]=true; }
                        if (c[n].child_j + 1 < m && !ball[c[n].child_i, c[n].child_j + 1])//右
                        { q.add(new Open(c[n].child_i, c[n].child_j + 1, c[n].child_i, c[n].child_j));ball[c[n].child_i, c[n].child_j + 1]=true;  }
                        if (c[n].child_i + 1 < m && !ball[c[n].child_i + 1, c[n].child_j])//下
                        { q.add(new Open(c[n].child_i + 1, c[n].child_j, c[n].child_i, c[n].child_j));ball[c[n].child_i + 1, c[n].child_j]=true; }
                    }
                    n++;
                }
            }
            if (c[n - 1].child_i == end_i && c[n - 1].child_j == end_j)//表示如果查找成功
            {
                int sum = 0;
                string res = end_i + "," + end_j;
                result[sum]=new int[]{end_i,end_j};
                int b_i = end_i, b_j = end_j;
                for (int i = n - 1; i > 0; i--)
                {
                    if (c[i].child_i == b_i && c[i].child_j == b_j)
                    {
                        sum++;
                        result[sum] = new int[] { c[i].parent_i,c[i].parent_j};
                        res = c[i].parent_i + "," + c[i].parent_j + "  " + res;
                        b_i = c[i].parent_i;
                        b_j = c[i].parent_j;
                    }
                }
                sum++;
                result[sum] = new int[] { sum,sum};//记录需移动的次数
                for (int i = 0; i < (sum + 1) / 2; i++)//数组倒序
                {
                    int[] temp = result[i];
                    result[i] = result[sum - i];
                    result[sum - i] = temp;
                }
                // MessageBox.Show("查找结果为：\n" + res, "查找成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result;

            }
            else
            {
                result[0] = new int[] { 0,0};
                return result;
            }

        }
    }
}
