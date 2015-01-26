﻿using System;
using System.Windows.Forms;
using WorkLogForm.WindowUiClass;
using WorkLogForm.Service;
using System.Collections;
using System.Collections.Generic;
using ClassLibrary;
using WorkLogForm.CommonClass;
using System.Drawing;

namespace WorkLogForm
{
    public partial class statistics_Attendance : Form
    {
        private List<Label> dateLabel = new List<Label>();
        IList attendanceList;
        UsuallyDay usuallyDay;
        char[] usuallyDayChar;
        IList holidayList;
        IList workDayList;
        IList leaveList;
        int leaveDayNum;
        private BaseService baseService = new BaseService();
        private WkTUser user;
        private WkTRole role;
        public WkTRole Role
        {
            get { return role; }
            set { role = value; }
        }
        public WkTUser User
        {
            get { return user; }
            set { user = value; }
        }
        public statistics_Attendance()
        {
            InitializeComponent();
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
        private void statistics_Attendance_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.x_point = e.X;
                this.y_point = e.Y;
            }
        }

        private void statistics_Attendance_MouseMove(object sender, MouseEventArgs e)
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
        #region 统计考勤
        private void init()
        {
            IList deptList = baseService.loadEntityList("from WkTDept");
            if (deptList != null && deptList.Count > 0)
            {
                foreach (WkTDept dept in deptList)
                {
                    dept_comboBox.Items.Add(dept.KdName.Trim());
                }
            }
            dept_comboBox.SelectedIndex = 0;
            loadData();
            dateTimePicker5.Value = DateTime.Now;
            this.initCalendar(dateTimePicker5.Value.Year, dateTimePicker5.Value.Month);
            updateLabel();
        }
        private void loadData()
        {
            dateLabel.Add(label111); dateLabel.Add(label122); dateLabel.Add(label133); dateLabel.Add(label144);
            dateLabel.Add(label155); dateLabel.Add(label166); dateLabel.Add(label177); dateLabel.Add(label211);
            dateLabel.Add(label222); dateLabel.Add(label233); dateLabel.Add(label244); dateLabel.Add(label255);
            dateLabel.Add(label266); dateLabel.Add(label277); dateLabel.Add(label311); dateLabel.Add(label322);
            dateLabel.Add(label333); dateLabel.Add(label344); dateLabel.Add(label355); dateLabel.Add(label366);
            dateLabel.Add(label377); dateLabel.Add(label411); dateLabel.Add(label422); dateLabel.Add(label433);
            dateLabel.Add(label444); dateLabel.Add(label455); dateLabel.Add(label466); dateLabel.Add(label477);
            dateLabel.Add(label511); dateLabel.Add(label522); dateLabel.Add(label533); dateLabel.Add(label544);
            dateLabel.Add(label555); dateLabel.Add(label566); dateLabel.Add(label577); dateLabel.Add(label611);
            dateLabel.Add(label622); dateLabel.Add(label633); dateLabel.Add(label644); dateLabel.Add(label655);
            dateLabel.Add(label666); dateLabel.Add(label677);
        }
        private void updateLabel()
        {
            attendenceLabel_Paint(label11); attendenceLabel_Paint(label21); attendenceLabel_Paint(label31); attendenceLabel_Paint(label41); attendenceLabel_Paint(label51); attendenceLabel_Paint(label61);
            attendenceLabel_Paint(label12); attendenceLabel_Paint(label22); attendenceLabel_Paint(label32); attendenceLabel_Paint(label42); attendenceLabel_Paint(label52); attendenceLabel_Paint(label62);
            attendenceLabel_Paint(label13); attendenceLabel_Paint(label23); attendenceLabel_Paint(label33); attendenceLabel_Paint(label43); attendenceLabel_Paint(label53); attendenceLabel_Paint(label63);
            attendenceLabel_Paint(label14); attendenceLabel_Paint(label24); attendenceLabel_Paint(label34); attendenceLabel_Paint(label44); attendenceLabel_Paint(label54); attendenceLabel_Paint(label64);
            attendenceLabel_Paint(label15); attendenceLabel_Paint(label25); attendenceLabel_Paint(label35); attendenceLabel_Paint(label45); attendenceLabel_Paint(label55); attendenceLabel_Paint(label65);
            attendenceLabel_Paint(label16); attendenceLabel_Paint(label26); attendenceLabel_Paint(label36); attendenceLabel_Paint(label46); attendenceLabel_Paint(label56); attendenceLabel_Paint(label66);
            attendenceLabel_Paint(label17); attendenceLabel_Paint(label27); attendenceLabel_Paint(label37); attendenceLabel_Paint(label47); attendenceLabel_Paint(label57); attendenceLabel_Paint(label67);
        }
        private void updatePanel()
        {
            attendencePanel_Paint(panel11); attendencePanel_Paint(panel21); attendencePanel_Paint(panel31); attendencePanel_Paint(panel41); attendencePanel_Paint(panel51); attendencePanel_Paint(panel61);
            attendencePanel_Paint(panel12); attendencePanel_Paint(panel22); attendencePanel_Paint(panel32); attendencePanel_Paint(panel42); attendencePanel_Paint(panel52); attendencePanel_Paint(panel62);
            attendencePanel_Paint(panel13); attendencePanel_Paint(panel23); attendencePanel_Paint(panel33); attendencePanel_Paint(panel43); attendencePanel_Paint(panel53); attendencePanel_Paint(panel63);
            attendencePanel_Paint(panel14); attendencePanel_Paint(panel24); attendencePanel_Paint(panel34); attendencePanel_Paint(panel44); attendencePanel_Paint(panel54); attendencePanel_Paint(panel64);
            attendencePanel_Paint(panel15); attendencePanel_Paint(panel25); attendencePanel_Paint(panel35); attendencePanel_Paint(panel45); attendencePanel_Paint(panel55); attendencePanel_Paint(panel65);
            attendencePanel_Paint(panel16); attendencePanel_Paint(panel26); attendencePanel_Paint(panel36); attendencePanel_Paint(panel46); attendencePanel_Paint(panel56); attendencePanel_Paint(panel66);
            attendencePanel_Paint(panel17); attendencePanel_Paint(panel27); attendencePanel_Paint(panel37); attendencePanel_Paint(panel47); attendencePanel_Paint(panel57); attendencePanel_Paint(panel67);
        }
        private void attendencePanel_Paint(Panel panel)
        {
            panel.BackgroundImage = WorkLogForm.Properties.Resources.日历小方块2;
            DateTime date = (DateTime)panel.Tag;
            int dayOfWeek = (int)date.DayOfWeek == 0 ? 6 : (int)date.DayOfWeek - 1;
            if (leaveList != null && leaveList.Count > 0)
            {
                foreach (LeaveManage a in leaveList)
                {
                    if (a.StartTime <= date.Date.Ticks && a.EndTime > date.Date.Ticks)
                    {
                        leaveDayNum++;
                        if (a.LeaveType == "婚假")
                        {
                            panel.BackgroundImage = WorkLogForm.Properties.Resources.日历小方块2_婚;
                        }
                        else if (a.LeaveType == "探亲假")
                        {
                            panel.BackgroundImage = WorkLogForm.Properties.Resources.日历小方块2_亲;
                        }
                        else if (a.LeaveType == "年休假")
                        {
                            panel.BackgroundImage = WorkLogForm.Properties.Resources.日历小方块2_年;
                        }
                        else if (a.LeaveType == "事假")
                        {
                            panel.BackgroundImage = WorkLogForm.Properties.Resources.日历小方块2_事;
                        }
                        else if (a.LeaveType == "病假")
                        {
                            panel.BackgroundImage = WorkLogForm.Properties.Resources.日历小方块2_病;
                        }
                        else if (a.LeaveType == "产假")
                        {
                            panel.BackgroundImage = WorkLogForm.Properties.Resources.日历小方块2_产;
                        }
                        panel.Tag = null;
                        break;
                    }
                }
            }
            if (workDayList != null && workDayList.Count > 0)//判断是不是补班
            {
                foreach (WorkDay a in workDayList)
                {
                    if (a.WorkDateTime == date.Date.Ticks)
                    {
                        return;
                    }
                }
            }
            if (holidayList != null && holidayList.Count > 0)//判断是否节假日
            {
                foreach (Holiday a in holidayList)
                {
                    if (a.StartTime <= date.Date.Ticks && a.EndTime > date.Date.Ticks)
                    {
                        Image img = new Bitmap(panel.BackgroundImage);
                        Graphics panelG = Graphics.FromImage(img);
                        panelG.DrawString(a.Name, new Font("华文楷体", (float)28.0, FontStyle.Regular), System.Drawing.Brushes.Black, new PointF(22, 45));
                        panel.BackgroundImage = img;
                        panel.Tag = null;
                        return;
                    }
                }
            }
            if (usuallyDayChar[dayOfWeek].Equals((char)UsuallyDay.workDayEnum.Holiday))//判断是否周六日
            {
                panel.BackgroundImage = WorkLogForm.Properties.Resources.日历小方块2_休;
                panel.Tag = null;
            }
        }
        private void initAttendanceDate()
        {
            if (dateLabel[dateLabel.Count - 1].Parent.Tag != null && dateLabel[0].Parent.Tag != null)
            {
                DateTime startTime = (DateTime)dateLabel[0].Parent.Tag;
                DateTime endTime = (DateTime)dateLabel[dateLabel.Count - 1].Parent.Tag;
                attendanceList = baseService.loadEntityList("select att from Attendance att left join att.User u left join u.Kdid dept where dept.KdName='" + dept_comboBox.Text.Trim() + "' and att.State=" + (int)IEntity.stateEnum.Normal + " and u.KuName='" + userName_textBox.Text.Trim() + "' and att.SignDate>=" + startTime.Date.Ticks + " and att.SignDate<=" + endTime.Date.Ticks);
            }
        }
        private void initPanelDate()
        {
            if (dateLabel[dateLabel.Count - 1].Parent.Tag != null && dateLabel[0].Parent.Tag != null)
            {
                DateTime startTime = (DateTime)dateLabel[0].Parent.Tag;
                DateTime endTime = (DateTime)dateLabel[dateLabel.Count - 1].Parent.Tag;
                holidayList = baseService.loadEntityList("from Holiday where STATE=" + (int)IEntity.stateEnum.Normal + " and ((StartTime>=" + startTime.Date.Ticks + " and StartTime<=" + endTime.Date.Ticks + ") or (EndTime>=" + startTime.Date.Ticks + " and EndTime<=" + endTime.Date.Ticks + ") or (StartTime>=" + startTime.Date.Ticks + " and EndTime<=" + endTime.Date.Ticks + ") or (StartTime<=" + startTime.Date.Ticks + " and EndTime>=" + endTime.Date.Ticks + "))");
                workDayList = baseService.loadEntityList("from WorkDay where STATE=" + (int)IEntity.stateEnum.Normal + " and workDateTime>=" + startTime.Date.Ticks + " and workDateTime<=" + endTime.Date.Ticks);
                leaveList = baseService.loadEntityList("from LeaveManage where State=" + (int)IEntity.stateEnum.Normal + " and Ku_Id=" + user.Id + " and ((StartTime>=" + startTime.Date.Ticks + " and StartTime<=" + endTime.Date.Ticks + ") or (EndTime>=" + startTime.Date.Ticks + " and EndTime<=" + endTime.Date.Ticks + ") or (StartTime>=" + startTime.Date.Ticks + " and EndTime<=" + endTime.Date.Ticks + ") or (StartTime<=" + startTime.Date.Ticks + " and EndTime>=" + endTime.Date.Ticks + "))");
                IList usuallyDayList = baseService.loadEntityList("from UsuallyDay where STATE=" + (int)IEntity.stateEnum.Normal + " and StartTime<=" + dateTimePicker5.Value.Date.Ticks + " order by StartTime desc");
                if (usuallyDayList != null && usuallyDayList.Count == 1)
                {
                    usuallyDay = (UsuallyDay)usuallyDayList[0];
                    usuallyDayChar = usuallyDay.WorkDay.ToCharArray();
                }
            }
        }
        /// <summary>
        /// 初始化日历日期
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        private void initCalendar(int year, int month)
        {
            DateTime selectDay = new DateTime(year, month, 1);
            CNDate selectDateTool = new CNDate(selectDay);
            CNDate beforeDateTool = new CNDate(month == 1 ? new DateTime(year - 1, 12, 1) : new DateTime(year, month - 1, 1));
            switch (selectDay.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    initDayOfCalendar(0, selectDateTool.GetDayNumOfMonth(), beforeDateTool.GetDayNumOfMonth()); break;
                case DayOfWeek.Monday:
                    initDayOfCalendar(1, selectDateTool.GetDayNumOfMonth(), beforeDateTool.GetDayNumOfMonth()); break;
                case DayOfWeek.Tuesday:
                    initDayOfCalendar(2, selectDateTool.GetDayNumOfMonth(), beforeDateTool.GetDayNumOfMonth()); break;
                case DayOfWeek.Wednesday:
                    initDayOfCalendar(3, selectDateTool.GetDayNumOfMonth(), beforeDateTool.GetDayNumOfMonth()); break;
                case DayOfWeek.Thursday:
                    initDayOfCalendar(4, selectDateTool.GetDayNumOfMonth(), beforeDateTool.GetDayNumOfMonth()); break;
                case DayOfWeek.Friday:
                    initDayOfCalendar(5, selectDateTool.GetDayNumOfMonth(), beforeDateTool.GetDayNumOfMonth()); break;
                case DayOfWeek.Saturday:
                    initDayOfCalendar(6, selectDateTool.GetDayNumOfMonth(), beforeDateTool.GetDayNumOfMonth()); break;
            }
        }
        /// <summary>
        /// 初始化日历日期子函数
        /// </summary>
        /// <param name="startDay"></param>
        /// <param name="allDay"></param>
        /// <param name="lastMonthLastDay"></param>
        private void initDayOfCalendar(int startDay, int allDay, int lastMonthLastDay)
        {
            for (int i = 0; i < dateLabel.Count; i++)
            {
                if (i < startDay)
                {
                    dateLabel[i].Text = (lastMonthLastDay - (startDay - i) + 1).ToString();
                    dateLabel[i].Parent.ForeColor = SystemColors.ControlDark;
                    if (!dateTimePicker5.Value.Month.Equals(1))
                    {
                        dateLabel[i].Parent.Tag = new DateTime(dateTimePicker5.Value.Year, dateTimePicker5.Value.Month - 1, lastMonthLastDay - (startDay - i) + 1);
                    }
                    else
                    {
                        dateLabel[i].Parent.Tag = new DateTime(dateTimePicker5.Value.Year - 1, 12, lastMonthLastDay - (startDay - i) + 1);
                    }
                }
                else if (i >= (startDay + allDay))
                {
                    dateLabel[i].Text = (i - (startDay + allDay) + 1).ToString();
                    dateLabel[i].Parent.ForeColor = SystemColors.ControlDark;
                    if (!dateTimePicker5.Value.Month.Equals(12))
                    {
                        dateLabel[i].Parent.Tag = new DateTime(dateTimePicker5.Value.Year, dateTimePicker5.Value.Month + 1, i - (startDay + allDay) + 1);
                    }
                    else
                    {
                        dateLabel[i].Parent.Tag = new DateTime(dateTimePicker5.Value.Year + 1, 1, i - (startDay + allDay) + 1);
                    }

                }
                else
                {
                    dateLabel[i].Text = (i - startDay + 1).ToString();
                    dateLabel[i].Parent.ForeColor = SystemColors.ControlText;
                    dateLabel[i].Parent.Tag = new DateTime(dateTimePicker5.Value.Year, dateTimePicker5.Value.Month, i - startDay + 1);
                }
            }

        }
        private void attendenceLabel_Paint(Label label)
        {
            label.Text = "";
            label.ForeColor = label.Parent.ForeColor;
            if (label.Parent.Tag == null)
            {
                return;
            }
            DateTime date = (DateTime)label.Parent.Tag;
            if (attendanceList != null)
            {
                foreach (Attendance a in attendanceList)
                {
                    if (a.SignDate == date.Date.Ticks)
                    {
                        label.Text += a.SignStartTime != 0 && a.SignStartTime <= usuallyDay.WorkTimeStart ? CNDate.getTimeByTimeTicks(a.SignStartTime) : "迟到";
                        label.Text += "~";
                        label.Text += a.SignEndTime != 0 && a.SignEndTime >= usuallyDay.WorkTimeEnd ? CNDate.getTimeByTimeTicks(a.SignEndTime) : "早退";
                        if (a.SignStartTime != 0 || a.SignStartTime <= usuallyDay.WorkTimeStart || a.SignEndTime != 0 || a.SignEndTime >= usuallyDay.WorkTimeEnd)
                        {
                            label.ForeColor = Color.Red;
                        }
                        attendanceList.Remove(a);
                        return;
                    }
                }
                label.Text += "缺勤";
                label.ForeColor = Color.Red;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            leaveDayNum = 0;
            int lateDayNum = 0;
            int earlyDayNum = 0;
            int noneAttNum = 0;
            this.initCalendar(dateTimePicker5.Value.Year, dateTimePicker5.Value.Month);
            initPanelDate();
            initAttendanceDate();
            updatePanel();
            updateLabel();
            #region 出勤统计数据初始化
            List<object> staticsList = new List<object>();
            DateTime startTime = new DateTime(dateTimePicker5.Value.Year, dateTimePicker5.Value.Month, 1);
            DateTime endTime = new DateTime(dateTimePicker5.Value.Year, dateTimePicker5.Value.Month, CNDate.GetDayNumOfMonth(new DateTime(dateTimePicker5.Value.Year, dateTimePicker5.Value.Month, 1)));
            IList staticAttendanceList = baseService.loadEntityList("select att from Attendance att left join att.User u left join u.Kdid dept where dept.KdName='" + dept_comboBox.Text.Trim() + "' and att.State=" + (int)IEntity.stateEnum.Normal + " and u.KuName='" + userName_textBox.Text.Trim() + "' and att.SignDate>=" + startTime.Date.Ticks + " and att.SignDate<=" + endTime.Date.Ticks);
            noneAttNum = CNDate.getWorkDayNum(startTime.Date, endTime.Date).Count - staticAttendanceList.Count;
            staticsList.Add(staticAttendanceList.Count);
            if (staticAttendanceList != null && staticAttendanceList.Count > 0)
            {
                foreach (Attendance att in staticAttendanceList)
                {
                    if (att.LateOrLeaveEarly.Equals((int)Attendance.lateOrLeaveEarlyEnum.Early))
                    {
                        earlyDayNum++;
                    }
                    else if (att.LateOrLeaveEarly.Equals((int)Attendance.lateOrLeaveEarlyEnum.Late))
                    {
                        lateDayNum++;
                    }
                    else if (att.LateOrLeaveEarly.Equals((int)Attendance.lateOrLeaveEarlyEnum.LateAndEarly))
                    {
                        lateDayNum++;
                        earlyDayNum++;
                    }
                }
            }
            staticsList.Add(lateDayNum);
            staticsList.Add(earlyDayNum);
            staticsList.Add(noneAttNum);
            staticsList.Add(leaveDayNum);
            #endregion
            listView2.Items.Clear();
            initListView2(listView2, staticsList);
        }
        private void initListView2(ListView listView, List<object> o)
        {
            ListViewItem item = new ListViewItem();
            ListViewItem.ListViewSubItem shi_chu_qin = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem chi_dao = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem zao_tui = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem que_qin = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem qing_jia = new ListViewItem.ListViewSubItem();
            shi_chu_qin.Text = o[0].ToString().Trim();
            chi_dao.Text = o[1].ToString().Trim();
            zao_tui.Text = o[2].ToString().Trim();
            que_qin.Text = o[3].ToString().Trim();
            qing_jia.Text = o[4].ToString().Trim();
            item.SubItems.Add(shi_chu_qin);
            item.SubItems.Add(chi_dao);
            item.SubItems.Add(zao_tui);
            item.SubItems.Add(que_qin);
            item.SubItems.Add(qing_jia);
            listView.Items.Add(item);
        }
        #endregion
        private void statistics_Attendance_Load(object sender, EventArgs e)
        {
            initialWindow();
            init();
        }
        private void initListView(ListView listView, Hashtable userList)
        {
            if (userList != null && userList.Count > 0)
            {
                int i = 1;
                foreach (Int64 key in userList.Keys)
                {
                    List<object> o = (List<object>)userList[key];
                    ListViewItem item = new ListViewItem();
                    item.Text = i.ToString();
                    ListViewItem.ListViewSubItem name = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem ying_shang_ban = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem shi_chu_qin = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem jia_ban = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem zhi_ban = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem qing_jia = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem wei_chu_qin = new ListViewItem.ListViewSubItem();
                    name.Text = o[0].ToString().Trim();
                    ying_shang_ban.Text = o[1].ToString().Trim();
                    shi_chu_qin.Text = o[2].ToString().Trim();
                    jia_ban.Text = o[3].ToString().Trim();
                    zhi_ban.Text = o[4].ToString().Trim();
                    qing_jia.Text = o[5].ToString().Trim();
                    //wei_chu_qin.Text = o[6].ToString().Trim();
                    item.SubItems.Add(name);
                    item.SubItems.Add(ying_shang_ban);
                    item.SubItems.Add(shi_chu_qin);
                    item.SubItems.Add(jia_ban);
                    item.SubItems.Add(zhi_ban);
                    item.SubItems.Add(qing_jia);
                    //item.SubItems.Add(wei_chu_qin);
                    listView.Items.Add(item);
                    i++;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            IList all_day = baseService.loadEntityList("select u from WkTUser u left join u.Kdid dept left join u.UserRole r where r.KrDESC='" + CommonClass.CommonStaticParameter.RoleDesc + "' and u.KuName like '%" + textBox2.Text.Trim() + "%' and dept.KdName like '%" + (comboBox1.Text.Trim() != "请选择" ? comboBox1.Text.Trim() : "") + "%'");
            int allDay = CNDate.getWorkDayNum(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date).Count;
            if (all_day != null && all_day.Count > 0)
            {
                foreach (WkTUser u in all_day)
                {
                    List<object> dayNum = new List<object>();
                    dayNum.Add(u.KuName);
                    dayNum.Add(allDay);
                    dayNum.Add(0);
                    dayNum.Add(0);
                    dayNum.Add(0);
                    dayNum.Add(0);
                    ht.Add(u.Id, dayNum);
                }
            }
            string sql = "select u.Ku_Id,count(attend.id) from LOG_T_ATTENDANCE attend left join WK_T_USER u on u.ku_id=attend.WkTUserId,WK_T_DEPT dept,Wk_T_UseRole ur,Wk_T_Role r where u.KU_ID=ur.KU_ID and ur.KR_ID=r.KR_ID and r.KR_DESC='" + CommonClass.CommonStaticParameter.RoleDesc + "' and dept.kd_id=u.kd_id and dept.kd_name like '%" + (comboBox1.Text.Trim() != "请选择" ? comboBox1.Text.Trim() : "") + "%' and u.ku_Name like '%" + textBox2.Text.Trim() + "%' and attend.SignDate>=" + dateTimePicker1.Value.Date.Ticks + " and attend.SignDate<=" + dateTimePicker2.Value.Date.Ticks + "group by u.ku_id";
            IList chu_qin = baseService.ExecuteSQL(sql);
            if (chu_qin != null && chu_qin.Count > 0)
            {
                foreach (Object[] o in chu_qin)
                {
                    try
                    {
                        List<object> dayNum = (List<object>)ht[Convert.ToInt64(o[0])];
                        dayNum[2] = (int)o[1];
                        ht[Convert.ToInt64(o[0])] = dayNum;
                    }
                    catch
                    {
                        return;
                    }
                    
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            string jb_sql = "select u.Ku_Id,sum(case when attend.STARTTIME>" + dateTimePicker1.Value.Date.Ticks + " then (case when attend.ENDTIME<" + dateTimePicker2.Value.Date.Ticks + " then " + new DateTime(1, 1, 2).Date.Ticks + "+attend.ENDTIME-attend.STARTTIME else " + new DateTime(1, 1, 2).Date.Ticks + "+" + dateTimePicker2.Value.Date.Ticks + "-attend.STARTTIME end) else (case when attend.ENDTIME<" + dateTimePicker2.Value.Date.Ticks + " then " + new DateTime(1, 1, 2).Date.Ticks + "+attend.ENDTIME-" + dateTimePicker1.Value.Date.Ticks + " else " + new DateTime(1, 1, 2).Date.Ticks + "+" + dateTimePicker2.Value.Date.Ticks + "-" + dateTimePicker1.Value.Date.Ticks + " end) end) from LOG_T_WORKOVERTIME attend left join WORKOVERTIME_M_WkTUser mu on mu.WORKMAN_ID=attend.id left join WK_T_USER u on mu.ku_id=u.KU_ID,WK_T_DEPT dept,Wk_T_UseRole ur,Wk_T_Role r where u.KU_ID=ur.KU_ID and ur.KR_ID=r.KR_ID and r.KR_DESC='" + CommonClass.CommonStaticParameter.RoleDesc + "' and dept.kd_id=u.kd_id and dept.kd_name like '%" + (comboBox1.Text.Trim() != "请选择" ? comboBox1.Text.Trim() : "") + "%' and u.ku_Name like '%" + textBox2.Text.Trim() + "%' and ((attend.STARTTIME<=" + dateTimePicker1.Value.Date.Ticks + " and attend.ENDTIME>=" + dateTimePicker1.Value.Date.Ticks + ") or (attend.STARTTIME>=" + dateTimePicker1.Value.Date.Ticks + " and attend.ENDTIME<=" + dateTimePicker2.Value.Date.Ticks + ") or (attend.STARTTIME<=" + dateTimePicker2.Value.Date.Ticks + " and attend.ENDTIME>=" + dateTimePicker2.Value.Date.Ticks + ")) group by u.ku_id";
            IList jia_ban = baseService.ExecuteSQL(jb_sql);
            if (jia_ban != null && jia_ban.Count > 0)
            {
                foreach (Object[] o in jia_ban)
                {
                    List<object> dayNum = (List<object>)ht[Convert.ToInt64(o[0])];
                    dayNum[3] = Convert.ToInt64(o[1]) / 864000000000;
                    ht[Convert.ToInt64(o[0])] = dayNum;
                }
            }
            string zb_sql = "select u.Ku_Id,count(attend.id) from LOG_T_ONDUTY attend left join ONDUTYTIME_M_WkTUser mu on mu.ONDUTY_STAFFID=attend.id left join WK_T_USER u on u.ku_id=mu.KU_ID,WK_T_DEPT dept,Wk_T_UseRole ur,Wk_T_Role r where u.KU_ID=ur.KU_ID and ur.KR_ID=r.KR_ID and r.KR_DESC='" + CommonClass.CommonStaticParameter.RoleDesc + "' and dept.kd_id=u.kd_id and dept.kd_name like '%" + (comboBox1.Text.Trim() != "请选择" ? comboBox1.Text.Trim() : "") + "%' and u.ku_Name like '%" + textBox2.Text.Trim() + "%' and attend.ONDUTY_TIME>=" + dateTimePicker1.Value.Date.Ticks + " and attend.ONDUTY_TIME<=" + dateTimePicker2.Value.Date.Ticks + "group by u.ku_id";
            IList zhi_ban = baseService.ExecuteSQL(zb_sql);
            if (zhi_ban != null && zhi_ban.Count > 0)
            {
                foreach (Object[] o in zhi_ban)
                {
                    List<object> dayNum = (List<object>)ht[Convert.ToInt64(o[0])];
                    dayNum[4] = (int)o[1];
                    ht[Convert.ToInt64(o[0])] = dayNum;
                }
            }
            string qj_sql = "select u.Ku_Id,sum(case when attend.LEAVE_STARTTIME>" + dateTimePicker1.Value.Date.Ticks + " then (case when attend.LEAVE_ENDTIME<" + dateTimePicker2.Value.Date.Ticks + " then " + new DateTime(1, 1, 2).Date.Ticks + "+attend.LEAVE_ENDTIME-attend.LEAVE_STARTTIME else " + new DateTime(1, 1, 2).Date.Ticks + "+" + dateTimePicker2.Value.Date.Ticks + "-attend.LEAVE_STARTTIME end) else (case when attend.LEAVE_ENDTIME<" + dateTimePicker2.Value.Date.Ticks + " then " + new DateTime(1, 1, 2).Date.Ticks + "+attend.LEAVE_ENDTIME-" + dateTimePicker1.Value.Date.Ticks + " else " + new DateTime(1, 1, 2).Date.Ticks + "+" + dateTimePicker2.Value.Date.Ticks + "-" + dateTimePicker1.Value.Date.Ticks + " end) end) from LOG_T_LEAVE attend left join WK_T_USER u on u.ku_id=attend.KU_ID,WK_T_DEPT dept,Wk_T_UseRole ur,Wk_T_Role r where u.KU_ID=ur.KU_ID and ur.KR_ID=r.KR_ID and r.KR_DESC='"+CommonClass.CommonStaticParameter.RoleDesc+"' and dept.kd_id=u.kd_id and dept.kd_name like '%" + (comboBox1.Text.Trim() != "请选择" ? comboBox1.Text.Trim() : "") + "%' and u.ku_Name like '%" + textBox2.Text.Trim() + "%' and ((attend.LEAVE_STARTTIME<=" + dateTimePicker1.Value.Date.Ticks + " and attend.LEAVE_ENDTIME>=" + dateTimePicker1.Value.Date.Ticks + ") or (attend.LEAVE_STARTTIME>=" + dateTimePicker1.Value.Date.Ticks + " and attend.LEAVE_ENDTIME<=" + dateTimePicker2.Value.Date.Ticks + ") or (attend.LEAVE_STARTTIME<=" + dateTimePicker2.Value.Date.Ticks + " and attend.LEAVE_ENDTIME>=" + dateTimePicker2.Value.Date.Ticks + ")) group by u.ku_id";
            IList qing_jia = baseService.ExecuteSQL(qj_sql);
            if (qing_jia != null && qing_jia.Count > 0)
            {
                foreach (Object[] o in qing_jia)
                {
                    List<object> dayNum = (List<object>)ht[Convert.ToInt64(o[0])];
                    dayNum[5] = Convert.ToInt64(o[1])/864000000000;
                    ht[Convert.ToInt64(o[0])] = dayNum;
                }
            }
            listView1.Items.Clear();
            initListView(listView1, ht);
        }

        private void all_static_pictureBox_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void att_static_pictureBox_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }
    }
}