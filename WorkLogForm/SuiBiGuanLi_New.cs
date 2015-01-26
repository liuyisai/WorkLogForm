﻿using ClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WorkLogForm.Service;
using WorkLogForm.WindowUiClass;

namespace WorkLogForm
{
    public partial class SuiBiGuanLi_New : Form
    {
        BaseService baseService = new BaseService();
        private WkTUser user;
        public WkTUser User
        {
            get { return user; }
            set { user = value; }
        }


        public SuiBiGuanLi_New()
        {
            InitializeComponent();
            initialWindow();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }


        private void SuiBiGuanLi_New_Load(object sender, EventArgs e)
        {
            if (user != null)
            {
              
                string sql = "from SuiBi  where STATE=" + (int)IEntity.stateEnum.Normal+ " and WkTUserId = " + user.Id +" and WriteTime > " + DateTime.Now.AddMonths(-1).Ticks;
                IList suibilist = baseService.loadEntityList(sql);
                ShowInFlowPanel(suibilist);
            }
            string sql2 = "from ";


            
        }




        #region 自定义窗体初始化方法
        /// <summary>
        /// 初始化window（界面效果）
        /// </summary>
        private void initialWindow()
        {
            creatWindow.SetFormRoundRectRgn(this, 15);
            creatWindow.SetFormShadow(this);
        }
        #endregion
        #region 最小化关闭按钮
        private void min_pictureBox_MouseEnter(object sender, EventArgs e)
        {
            min_pictureBox.BackgroundImage = WorkLogForm.Properties.Resources.最小化_副本;
        }
        private void min_pictureBox_MouseLeave(object sender, EventArgs e)
        {
            min_pictureBox.BackgroundImage = WorkLogForm.Properties.Resources.最小化渐变;
        }
        private void min_pictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void close_pictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void close_pictureBox_MouseEnter(object sender, EventArgs e)
        {
            close_pictureBox.BackgroundImage = WorkLogForm.Properties.Resources.关闭渐变_副本;
        }
        private void close_pictureBox_MouseLeave(object sender, EventArgs e)
        {
            close_pictureBox.BackgroundImage = WorkLogForm.Properties.Resources.关闭渐变;
        }
        #endregion
        #region 窗体移动代码
        private int x_point, y_point;
        private void SuiBiGuanLi_New_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.x_point = e.X;
                this.y_point = e.Y;
            }
        }

        private void SuiBiGuanLi_New_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.Location.Y > 0)
            {
                Top = MousePosition.Y - y_point;
                Left = MousePosition.X - x_point;
            }
            else if (e.Button == MouseButtons.Left && e.Y > this.y_point)
            {
                Top = MousePosition.Y - y_point;
                Left = MousePosition.X - x_point;
            }
        }
        #endregion

        private void MyOwnSuiBi_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void OtherSuiBi_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void SearchSuiBi_pictureBox_Click(object sender, EventArgs e)
        {

        }

        public void ShowInFlowPanel(IList SuiBiList)
        {
            if (  SuiBiList != null&&SuiBiList.Count > 0)
            {

                ShowMyOwnSuiBi.Controls.Clear();
                foreach (SuiBi o in SuiBiList)
                {

                    Panel newpanel = new Panel();

                    Label content = new Label();
                    content.Font = new Font(new FontFamily("微软雅黑"), 12);
                    content.AutoSize = false;

                    int contentheight = ((o.Contents.ToString().Length / 44) + 1) * 22;
                    content.Size = new Size(720, contentheight);
                    content.Text = o.Contents.ToString();
                    content.Location = new Point(5, 14);


                    LinkLabel deleteSuiBi = new LinkLabel();
                    deleteSuiBi.Text = "删除";
                    deleteSuiBi.LinkColor = Color.Blue;
                    deleteSuiBi.Font = new System.Drawing.Font(new FontFamily("微软雅黑"), 9);
                    deleteSuiBi.Click += deleteSuiBi_Click;
                    deleteSuiBi.Location = new Point(681, content.Height + 10);
                    deleteSuiBi.Tag = o;



                    Label time = new Label();
                    time.Font = new Font(new FontFamily("微软雅黑"), 11);
                    time.AutoSize = true;
                    time.Location = new Point(500, content.Height + 10);
                    time.Text = new DateTime(Convert.ToInt64(o.WriteTime.ToString())).ToString("yyyy年MM月dd日 hh:mm");

                    newpanel.Size = new Size(732, content.Height + time.Height + 25);
                    newpanel.Parent = ShowMyOwnSuiBi;

                   

                    content.Parent = newpanel;
                    time.Parent = newpanel;
                    deleteSuiBi.Parent = newpanel;

                   
                    //消除闪烁
                    //ShowMyOwnSuiBi.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance| System.Reflection.BindingFlags.NonPublic).SetValue(newpanel, true, null);

                }

            }
        }

        void deleteSuiBi_Click(object sender, EventArgs e)
        {
            LinkLabel theLinklabel = (LinkLabel)sender;
            SuiBi thesuibi = theLinklabel.Tag as SuiBi;
            baseService.deleteEntity(thesuibi);

            Panel thepanel = theLinklabel.Parent as Panel;
            int index = thepanel.Parent.Controls.IndexOf(thepanel);
           
            //消除闪烁
            //ShowMyOwnSuiBi.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(thepanel, true, null);

            ShowMyOwnSuiBi.Controls.RemoveAt(index);
        }


        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.ShowMyOwnSuiBi.Visible = false;

            this.button1.Cursor = Cursors.WaitCursor;
            if (user != null)
            {

                string sql = "from SuiBi  where STATE=" + (int)IEntity.stateEnum.Normal + " and WkTUserId = " + user.Id + " and WriteTime > " + this.dateTimePicker1.Value.Ticks + " and WriteTime < " + this.dateTimePicker2.Value.Ticks + "and Contents like '%" + this.textBox1.Text + "%'";
                IList suibilist = baseService.loadEntityList(sql);
                ShowInFlowPanel(suibilist);
            }
            
            this.ShowMyOwnSuiBi.Visible = true;
            if (this.ShowMyOwnSuiBi.Visible == true)
            {
                this.button1.Cursor = Cursors.Hand;
            }
        }


        /// <summary>
        /// 查询其他的随笔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

        }


      

    }
}