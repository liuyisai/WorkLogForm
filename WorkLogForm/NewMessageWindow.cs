﻿using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkLogForm.Service;

namespace WorkLogForm
{
    public partial class NewMessageWindow : Form
    {
        private BaseService baseService = new BaseService();
        private List<KjqbService.LogInService> loglist;
        private List<KjqbService.ScheduleInService> schedulelist;
        private List<KjqbService.CommentInService> commentList;
        private List<KjqbService.TimeArrangeForManagerInService> tfmlist;
        private List<KjqbService.LeaveInService> levlist;
        Leave leaveWindow;
        WkTRole role;
        public WkTRole Role
        {
            get { return role; }
            set { role = value; }
        }

        public Leave LeaveWindow
        {
            get { return leaveWindow; }
            set { leaveWindow = value; }
        }
        public List<KjqbService.LeaveInService> Levlist
        {
            get { return levlist; }
            set { levlist = value; }
        }


        public List<KjqbService.TimeArrangeForManagerInService> Tfmlist
        {
            get { return tfmlist; }
            set { tfmlist = value; }
        }

        public List<KjqbService.CommentInService> CommentList
        {
            get { return commentList; }
            set { commentList = value; }
        }
        public List<KjqbService.ScheduleInService> Schedulelist
        {
            get { return schedulelist; }
            set { schedulelist = value; }
        }
        private WkTUser user;

        public WkTUser User
        {
            get { return user; }
            set { user = value; }
        }
        public List<KjqbService.LogInService> Loglist
        {
            get { return loglist; }
            set { loglist = value; }
        }
        

        private Point formLocation;

        public Point FormLocation
        {
            get { return formLocation; }
            set { formLocation = value; }
        }
        public NewMessageWindow()
        {
            InitializeComponent();
            loglist = new List<KjqbService.LogInService>();
            schedulelist = new List<KjqbService.ScheduleInService>();
            commentList = new List<KjqbService.CommentInService>();
            tfmlist = new List<KjqbService.TimeArrangeForManagerInService>();
            levlist = new List<KjqbService.LeaveInService>();
            user = new WkTUser();

        }

        private void close_pictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region 窗体加载
        private void NewMessageWindow_Load(object sender, EventArgs e)
        {
            if (this.formLocation != null)
            {
                this.Location = formLocation;
            }

            if (loglist != null && loglist.Count > 0)
            {
                loglist.Reverse();
                foreach (KjqbService.LogInService ll in Loglist)
                {
                    StaffLog ss = new StaffLog();
                    ss = (StaffLog)baseService.loadEntity(ss, ll.LogId);
                    LinkLabel l1 = new LinkLabel();
                    l1.Text = ss.Staff.KuName + "分享给您的日志";
                    l1.Width = this.flowLayoutPanel1.Width - 10;
                    l1.Height = 30;
                    l1.Top = 10;
                    l1.Tag = ss;
                    l1.Click += l1_Click;
                    l1.Parent = flowLayoutPanel1;
                }
            }

            if (schedulelist != null && schedulelist.Count > 0)
            {
                schedulelist.Reverse();
                foreach (KjqbService.ScheduleInService ll in schedulelist)
                {
                    StaffSchedule ss = new StaffSchedule();
                    //string sql = "select u from StaffLog u where u.Id = " + ll.LogId;
                    ss = (StaffSchedule)baseService.loadEntity(ss, ll.ScheduleId);
                    LinkLabel l1 = new LinkLabel();
                    if(ss.Staff.Id  == ss.ArrangeMan.Id)
                    {
                        l1.Text = ss.Staff.KuName + "分享给您的日程";
                        l1.Width = this.flowLayoutPanel1.Width - 10;
                        l1.Height = 30;
                        l1.Top = 10;
                        l1.Tag = ss;
                        l1.Click += l1_Click;
                        l1.Parent = flowLayoutPanel1;
                    }
                    else if (ss.Staff.Id != ss.ArrangeMan.Id)
                    {
                        l1.Text = ss.ArrangeMan.KuName + "给您安排的日程";
                        l1.Width = this.flowLayoutPanel1.Width - 10;
                        l1.Height = 30;
                        l1.Top = 10;
                        l1.Tag = ss;
                        l1.Click += l1_Click;
                        l1.Parent = flowLayoutPanel1;
                    }
                    
                }
            }

            if (commentList != null && commentList.Count > 0)
            {
                commentList.Reverse();
                foreach (KjqbService.CommentInService ll in commentList)
                {
                    StaffLog ss = new StaffLog();
                    //string sql = "select u from StaffLog u where u.Id = " + ll.LogId;
                    ss = (StaffLog)baseService.loadEntity(ss, ll.LogId);
                    LinkLabel l1 = new LinkLabel();
                    l1.Text = ll.CommentUserName + "评论了您的日志";
                    l1.Width = this.flowLayoutPanel1.Width - 10;
                    l1.Height = 30;
                    l1.Top = 10;
                    l1.Tag = ss;
                    l1.Click += l1_Click;
                    l1.Parent = flowLayoutPanel1;
                }
            }

            if(tfmlist != null && tfmlist.Count >0)
            {
                tfmlist.Reverse();
                foreach(KjqbService.TimeArrangeForManagerInService tfm in tfmlist)
                {
                    TimeArrangeForManager tt = new TimeArrangeForManager();
                    tt = (TimeArrangeForManager)baseService.loadEntity(tt,tfm.TimeArrangeForManagerId);
                    LinkLabel l1 = new LinkLabel();
                    l1.Width = this.flowLayoutPanel1.Width - 10;
                    l1.Height = 30;
                    l1.Top = 10;
                    l1.Tag = tt;
                    l1.Click += l1_Click;
                    l1.Parent = flowLayoutPanel1;
                    DateTime dt = new DateTime(tt.TimeMonth);
                    if (tfm.ExamineOrExamineresult == 0)
                    {
                        l1.Text = dt.ToString("yyyy年MM月")+" "+"排班待您审核";
                    }
                    if (tfm.ExamineOrExamineresult == 1)
                    {
                        l1.Text = dt.ToString("yyyy年MM月") + " " + "排班审核通过";
                    }
                    if (tfm.ExamineOrExamineresult == 2)
                    {
                        l1.Text = dt.ToString("yyyy年MM月") + " " + "排班审核未通过";
                    }
                    if (tfm.ExamineOrExamineresult == 3)
                    {
                        l1.Text = "请您安排"+dt.ToString("yyyy年MM月")+"的值班";
                    }
                
                }
            
            }

            if (levlist != null && levlist.Count > 0)
            {
                levlist.Reverse();
                foreach (KjqbService.LeaveInService tfm in levlist)
                {
                    LeaveManage tt = new LeaveManage();
                    tt = (LeaveManage)baseService.loadEntity(tt, tfm.LeaveId);
                    LinkLabel l1 = new LinkLabel();
                    l1.Width = this.flowLayoutPanel1.Width - 10;
                    l1.Height = 30;
                    l1.Top = 10;
                    l1.Tag = tt;
                    l1.Click += l1_Click;
                    l1.Parent = flowLayoutPanel1;
                   
                    if (tfm.ExamineOrExamineresult == 0)
                    {
                        l1.Text = tt.Ku_Id.KuName + "请假申请待您审核";
                    }
                    DateTime dt1 = new DateTime(tt.StartTime);
                    DateTime dt2 = new DateTime(tt.EndTime);

                    if (tfm.ExamineOrExamineresult == 1)
                    {
                        l1.Text = "您提交的"+tt.LeaveType+"申请审核通过";
                    }
                    if (tfm.ExamineOrExamineresult == 2)
                    {
                        l1.Text = "您提交的" + tt.LeaveType + "申请审核未通过";
                    }

                }
            }
          
        }

        void l1_Click(object sender, EventArgs e)
        {
            LinkLabel l1 = (LinkLabel)sender;

            if (l1.Tag.GetType() == typeof(StaffLog))
            {
                StaffLog ss = (StaffLog)l1.Tag;
                writeLog wl = new writeLog();
                wl.User = ss.Staff;
                wl.LogDate = new DateTime(ss.WriteTime);
                wl.IsComment = true;
                wl.CommentPersonName = this.User.KuName;
                wl.ShowDialog();
            }
            else if (l1.Tag.GetType() == typeof(StaffSchedule))
            {
                StaffSchedule ss = (StaffSchedule)l1.Tag;
                DateTime dt = new DateTime(ss.ScheduleTime);
                MessageBox.Show(dt.ToString("yyyy-MM-dd HH:mm:ss")+" :"+ss.Content);
            }
            else if (l1.Tag.GetType() == typeof(LeaveManage))
            {
                if (leaveWindow == null || leaveWindow.IsDisposed)
                {
                    leaveWindow = new Leave();
                    leaveWindow.Leaveman = this.user;
                    leaveWindow.Role = role;
                }
                if (!leaveWindow.Created)
                {
                    leaveWindow.Show();
                }
                else
                {
                    leaveWindow.WindowState = FormWindowState.Normal;
                    leaveWindow.Focus();
                }
            }

        }
        #endregion








    }
}
