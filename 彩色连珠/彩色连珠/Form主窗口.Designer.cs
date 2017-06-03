namespace 彩色连珠
{
    partial class Form主窗口
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form主窗口));
            this.panel游戏区 = new System.Windows.Forms.Panel();
            this.label分数 = new System.Windows.Forms.Label();
            this.timer移动 = new System.Windows.Forms.Timer(this.components);
            this.timer缩放 = new System.Windows.Forms.Timer(this.components);
            this.label最高分 = new System.Windows.Forms.Label();
            this.groupBox下一组 = new System.Windows.Forms.GroupBox();
            this.groupBox成绩 = new System.Windows.Forms.GroupBox();
            this.button开始 = new System.Windows.Forms.Button();
            this.groupBox小提示 = new System.Windows.Forms.GroupBox();
            this.label提示 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.成绩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看成绩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button悔棋 = new System.Windows.Forms.Button();
            this.button以后再玩 = new System.Windows.Forms.Button();
            this.pictureBox下一组 = new System.Windows.Forms.PictureBox();
            this.重新开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分享到新浪微博ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox下一组.SuspendLayout();
            this.groupBox成绩.SuspendLayout();
            this.groupBox小提示.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox下一组)).BeginInit();
            this.SuspendLayout();
            // 
            // panel游戏区
            // 
            this.panel游戏区.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel游戏区.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel游戏区.Location = new System.Drawing.Point(0, 28);
            this.panel游戏区.Name = "panel游戏区";
            this.panel游戏区.Size = new System.Drawing.Size(674, 627);
            this.panel游戏区.TabIndex = 1;
            this.panel游戏区.Paint += new System.Windows.Forms.PaintEventHandler(this.panel游戏区_Paint);
            this.panel游戏区.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel游戏区_MouseClick);
            this.panel游戏区.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel游戏区_MouseMove);
            // 
            // label分数
            // 
            this.label分数.AutoSize = true;
            this.label分数.Font = new System.Drawing.Font("黑体", 18F);
            this.label分数.ForeColor = System.Drawing.Color.Blue;
            this.label分数.Location = new System.Drawing.Point(7, 59);
            this.label分数.Name = "label分数";
            this.label分数.Size = new System.Drawing.Size(94, 24);
            this.label分数.TabIndex = 3;
            this.label分数.Text = "分数：0";
            // 
            // timer移动
            // 
            this.timer移动.Interval = 30;
            this.timer移动.Tick += new System.EventHandler(this.timer移动_Tick);
            // 
            // timer缩放
            // 
            this.timer缩放.Interval = 70;
            this.timer缩放.Tick += new System.EventHandler(this.timer缩放_Tick);
            // 
            // label最高分
            // 
            this.label最高分.AutoSize = true;
            this.label最高分.Font = new System.Drawing.Font("黑体", 18F);
            this.label最高分.ForeColor = System.Drawing.Color.Red;
            this.label最高分.Location = new System.Drawing.Point(7, 26);
            this.label最高分.Name = "label最高分";
            this.label最高分.Size = new System.Drawing.Size(118, 24);
            this.label最高分.TabIndex = 4;
            this.label最高分.Text = "最高分：0";
            // 
            // groupBox下一组
            // 
            this.groupBox下一组.Controls.Add(this.pictureBox下一组);
            this.groupBox下一组.Font = new System.Drawing.Font("黑体", 12F);
            this.groupBox下一组.Location = new System.Drawing.Point(689, 136);
            this.groupBox下一组.Name = "groupBox下一组";
            this.groupBox下一组.Size = new System.Drawing.Size(181, 98);
            this.groupBox下一组.TabIndex = 5;
            this.groupBox下一组.TabStop = false;
            this.groupBox下一组.Text = "下一组";
            // 
            // groupBox成绩
            // 
            this.groupBox成绩.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox成绩.Controls.Add(this.label最高分);
            this.groupBox成绩.Controls.Add(this.label分数);
            this.groupBox成绩.Font = new System.Drawing.Font("黑体", 12F);
            this.groupBox成绩.Location = new System.Drawing.Point(689, 28);
            this.groupBox成绩.Name = "groupBox成绩";
            this.groupBox成绩.Size = new System.Drawing.Size(181, 102);
            this.groupBox成绩.TabIndex = 6;
            this.groupBox成绩.TabStop = false;
            this.groupBox成绩.Text = "成绩";
            // 
            // button开始
            // 
            this.button开始.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button开始.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button开始.Location = new System.Drawing.Point(689, 407);
            this.button开始.Name = "button开始";
            this.button开始.Size = new System.Drawing.Size(181, 66);
            this.button开始.TabIndex = 7;
            this.button开始.Text = "重新开始";
            this.button开始.UseVisualStyleBackColor = true;
            this.button开始.Click += new System.EventHandler(this.button开始_Click);
            // 
            // groupBox小提示
            // 
            this.groupBox小提示.Controls.Add(this.label提示);
            this.groupBox小提示.Font = new System.Drawing.Font("黑体", 12F);
            this.groupBox小提示.Location = new System.Drawing.Point(689, 250);
            this.groupBox小提示.Name = "groupBox小提示";
            this.groupBox小提示.Size = new System.Drawing.Size(181, 141);
            this.groupBox小提示.TabIndex = 8;
            this.groupBox小提示.TabStop = false;
            this.groupBox小提示.Text = "小提示";
            // 
            // label提示
            // 
            this.label提示.Font = new System.Drawing.Font("宋体", 12F);
            this.label提示.ForeColor = System.Drawing.Color.Fuchsia;
            this.label提示.Location = new System.Drawing.Point(11, 26);
            this.label提示.Name = "label提示";
            this.label提示.Size = new System.Drawing.Size(164, 104);
            this.label提示.TabIndex = 0;
            this.label提示.Text = "5个相同颜色的球在一起会消掉，同时加10分，6个球加20分，7个球30分，依次类推，但棋盘越满，难度越大。";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem,
            this.成绩ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(883, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重新开始ToolStripMenuItem,
            this.分享到新浪微博ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.游戏ToolStripMenuItem.Text = "游戏(&G)";
            // 
            // 成绩ToolStripMenuItem
            // 
            this.成绩ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看成绩ToolStripMenuItem});
            this.成绩ToolStripMenuItem.Name = "成绩ToolStripMenuItem";
            this.成绩ToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.成绩ToolStripMenuItem.Text = "成绩(&S)";
            // 
            // 查看成绩ToolStripMenuItem
            // 
            this.查看成绩ToolStripMenuItem.Name = "查看成绩ToolStripMenuItem";
            this.查看成绩ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.查看成绩ToolStripMenuItem.Text = "查看成绩(&C)";
            this.查看成绩ToolStripMenuItem.Click += new System.EventHandler(this.查看成绩ToolStripMenuItem_Click_1);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem1,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.帮助ToolStripMenuItem1.Text = "帮助(&H)";
            this.帮助ToolStripMenuItem1.Click += new System.EventHandler(this.帮助ToolStripMenuItem1_Click_1);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.关于ToolStripMenuItem.Text = "关于(&A)";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click_1);
            // 
            // button悔棋
            // 
            this.button悔棋.Enabled = false;
            this.button悔棋.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button悔棋.Location = new System.Drawing.Point(689, 488);
            this.button悔棋.Name = "button悔棋";
            this.button悔棋.Size = new System.Drawing.Size(178, 66);
            this.button悔棋.TabIndex = 10;
            this.button悔棋.Text = "悔棋";
            this.button悔棋.UseVisualStyleBackColor = true;
            this.button悔棋.Click += new System.EventHandler(this.button悔棋_Click);
            // 
            // button以后再玩
            // 
            this.button以后再玩.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button以后再玩.Location = new System.Drawing.Point(689, 570);
            this.button以后再玩.Name = "button以后再玩";
            this.button以后再玩.Size = new System.Drawing.Size(178, 66);
            this.button以后再玩.TabIndex = 11;
            this.button以后再玩.Text = "以后再玩";
            this.button以后再玩.UseVisualStyleBackColor = true;
            this.button以后再玩.Click += new System.EventHandler(this.button以后再玩_Click);
            // 
            // pictureBox下一组
            // 
            this.pictureBox下一组.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox下一组.Location = new System.Drawing.Point(3, 22);
            this.pictureBox下一组.Name = "pictureBox下一组";
            this.pictureBox下一组.Size = new System.Drawing.Size(175, 73);
            this.pictureBox下一组.TabIndex = 0;
            this.pictureBox下一组.TabStop = false;
            // 
            // 重新开始ToolStripMenuItem
            // 
            this.重新开始ToolStripMenuItem.Image = global::彩色连珠.Properties.Resources.Play;
            this.重新开始ToolStripMenuItem.Name = "重新开始ToolStripMenuItem";
            this.重新开始ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.重新开始ToolStripMenuItem.Text = "重新开始(&S)";
            this.重新开始ToolStripMenuItem.Click += new System.EventHandler(this.重新开始ToolStripMenuItem_Click_1);
            // 
            // 分享到新浪微博ToolStripMenuItem
            // 
            this.分享到新浪微博ToolStripMenuItem.Image = global::彩色连珠.Properties.Resources.SinaWeibo_PNG;
            this.分享到新浪微博ToolStripMenuItem.Name = "分享到新浪微博ToolStripMenuItem";
            this.分享到新浪微博ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.分享到新浪微博ToolStripMenuItem.Text = "分享到新浪微博";
            this.分享到新浪微博ToolStripMenuItem.Click += new System.EventHandler(this.分享到新浪微博ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Image = global::彩色连珠.Properties.Resources.Delete;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.退出ToolStripMenuItem.Text = "退出(&E)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click_1);
            // 
            // Form主窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 674);
            this.Controls.Add(this.button以后再玩);
            this.Controls.Add(this.button悔棋);
            this.Controls.Add(this.groupBox小提示);
            this.Controls.Add(this.button开始);
            this.Controls.Add(this.groupBox成绩);
            this.Controls.Add(this.groupBox下一组);
            this.Controls.Add(this.panel游戏区);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form主窗口";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仙安彩色连珠 v1.4";
            this.Load += new System.EventHandler(this.Form主窗口_Load);
            this.groupBox下一组.ResumeLayout(false);
            this.groupBox成绩.ResumeLayout(false);
            this.groupBox成绩.PerformLayout();
            this.groupBox小提示.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox下一组)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel游戏区;
        private System.Windows.Forms.Timer timer移动;
        private System.Windows.Forms.Timer timer缩放;
        private System.Windows.Forms.Label label最高分;
        private System.Windows.Forms.GroupBox groupBox下一组;
        private System.Windows.Forms.GroupBox groupBox成绩;
        private System.Windows.Forms.Button button开始;
        private System.Windows.Forms.PictureBox pictureBox下一组;
        private System.Windows.Forms.GroupBox groupBox小提示;
        private System.Windows.Forms.Label label提示;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重新开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 成绩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看成绩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分享到新浪微博ToolStripMenuItem;
        private System.Windows.Forms.Button button悔棋;
        private System.Windows.Forms.Button button以后再玩;
        public System.Windows.Forms.Label label分数;
    }
}

