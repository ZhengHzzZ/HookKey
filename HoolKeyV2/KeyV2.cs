using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HookKeyV2
{
    public partial class KeyV2 : Form
    {
        private int m_selectedOri = -1;
        public KeyV2()
        {
            InitializeComponent();

            #region 注册事件
            this.Load += new EventHandler(KeyV2_Load);
            this.FormClosing += new FormClosingEventHandler(KeyV2_FormClosing);
            this.pnlFlip.Click += new EventHandler(pnlFlip_Click);

            this.txtAddOri.Enter += new EventHandler(txt_Enter);
            this.txtAddOri.LostFocus += new EventHandler(txt_LostFocus);
            this.txtAddTar.Enter += new EventHandler(txt_Enter);
            this.txtAddTar.LostFocus += new EventHandler(txt_LostFocus);
            this.txtChangeOri.Enter += new EventHandler(txt_Enter);
            this.txtChangeOri.LostFocus += new EventHandler(txt_LostFocus);
            this.txtChangeTar.Enter += new EventHandler(txt_Enter);
            this.txtChangeTar.LostFocus += new EventHandler(txt_LostFocus);

            KeyHook.Event_WinFunc += new KeyHook.WindowFunc(KeyHook_Event_WinFunc);
            #endregion
        }

        #region 窗体事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void KeyV2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(100, 320 - 243);
            this.listView1.MultiSelect = false;
            KeyConfig.Initialize();
            this.RefreshControl();
        }
        /// <summary>
        /// 更改窗体大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pnlFlip_Click(object sender, EventArgs e)
        {
            if (this.Size.Height < 100)
            {
                this.Size = new Size(410, 320);
                this.pnlFlip.Cursor = System.Windows.Forms.Cursors.PanNorth;
            }
            else
            {
                this.Size = new Size(100, 320 - 243);
                this.pnlFlip.Cursor = System.Windows.Forms.Cursors.PanSouth;
            }
        }
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void KeyV2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.btnStartAndStop.Text.Equals("结束"))
            {
                bool b = KeyHook.UnHook(KeyHook.Hook);
            }
        }
        /// <summary>
        /// 窗体事件
        /// </summary>
        void KeyHook_Event_WinFunc()
        {
            this.label8.Focus();
        }
        #endregion

        #region 开始/结束
        /// <summary>
        /// 开始/结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartAndStop_Click(object sender, EventArgs e)
        {
            if (this.btnStartAndStop.Text.Equals("开始"))
            {
                this.btnStartAndStop.Text = "结束";
                KeyHook.Hook = KeyHook.SetHook(KeyHook.WH_KEYBOARD_LL, KeyHook.ChangeKey);
            }
            else
            {
                this.btnStartAndStop.Text = "开始";
                bool b = KeyHook.UnHook(KeyHook.Hook);
                if (!b)
                    MessageBox.Show("解钩失败了,我也不知道怎么办……");
            }
        }
        #endregion

        #region 添加、修改、删除
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ori = int.Parse(this.txtAddOri.Tag.ToString());
            int tar = int.Parse(this.txtAddTar.Tag.ToString());
            if (ori < 0 || tar < 0)
            {
                MessageBox.Show("请先点击文本框输入按键");
                return;
            }
            if (KeyConfig.DicKeys.ContainsKey(ori))
            {
                MessageBox.Show("已存在相同按键");
            }
            else
            {
                KeyConfig.DicKeys.Add(ori, tar);
            }
            this.RefreshControl();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            int ori = int.Parse(this.txtChangeOri.Tag.ToString());
            int tar = int.Parse(this.txtChangeTar.Tag.ToString());
            if (ori < 0 || tar < 0)
            {
                MessageBox.Show("请先点击文本框输入按键");
                return;
            }
            else
            {
                if (this.m_selectedOri != -1)
                {
                    KeyConfig.DicKeys.Remove(this.m_selectedOri);
                    KeyConfig.DicKeys.Add(ori, tar);
                }
            }
            this.RefreshControl();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.m_selectedOri != -1)
            {
                KeyConfig.DicKeys.Remove(this.m_selectedOri);
            }
            this.RefreshControl();
        }
        #endregion

        #region ListView事件
        /// <summary>
        /// ListView选择项事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems != null)
                {
                    if (this.listView1.SelectedItems.Count > 0)
                    {
                        ListViewItem item = this.listView1.SelectedItems[0];
                        int[] keyArray = item.Tag as int[];
                        if (keyArray != null)
                        {
                            m_selectedOri = keyArray[0];
                            this.txtChangeOri.Text = ((Keys)keyArray[0]).ToString();
                            this.txtChangeTar.Text = ((Keys)keyArray[1]).ToString();
                            this.txtChangeOri.Tag = keyArray[0];
                            this.txtChangeTar.Tag = keyArray[1];
                        }
                    }
                    else
                    {
                        this.txtChangeOri.Tag = -1;
                        this.txtChangeTar.Tag = -1;
                        //MessageBox.Show("请先选择已有按键");
                        RefreshControl();
                    }
                }
            }
            catch 
            {
                
            }
        }
        #endregion

        #region 文本框事件
        bool flag = false;
        /// <summary>
        /// 文本框获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void txt_Enter(object sender, EventArgs e)
        {
            if (this.btnStartAndStop.Text == "结束")
            {
                bool b = KeyHook.UnHook(KeyHook.Hook);
            }
            TextBox tb = sender as TextBox;
            switch (tb.Name)
            {
                case "txtAddOri":
                    this.txtAddOri.Text = "";
                    break;
                case "txtAddTar":
                    this.txtAddTar.Text = "";
                    break;
                case "txtChangeOri":
                    this.txtChangeOri.Text = "";
                    break;
                case "txtChangeTar":
                    this.txtChangeTar.Text = "";
                    break;
                default:
                    break;
            }
            flag = true;
            KeyHook.GetKeyHook = KeyHook.SetHook(KeyHook.WH_KEYBOARD_LL, KeyHook.GetKey);
        }
        /// <summary>
        /// 文本框失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void txt_LostFocus(object sender, EventArgs e)
        {
            if (!flag)
                return;
            TextBox tb = sender as TextBox;
            switch (tb.Name)
            {
                case "txtAddOri":
                    this.txtAddOri.Text = ((Keys)KeyHook.GetKeyCode).ToString();
                    this.txtAddOri.Tag = KeyHook.GetKeyCode;
                    break;
                case "txtAddTar":
                    this.txtAddTar.Text = ((Keys)KeyHook.GetKeyCode).ToString();
                    this.txtAddTar.Tag = KeyHook.GetKeyCode;
                    break;
                case "txtChangeOri":
                    this.txtChangeOri.Text = ((Keys)KeyHook.GetKeyCode).ToString();
                    this.txtChangeOri.Tag = KeyHook.GetKeyCode;
                    break;
                case "txtChangeTar":
                    this.txtChangeTar.Text = ((Keys)KeyHook.GetKeyCode).ToString();
                    this.txtChangeTar.Tag = KeyHook.GetKeyCode;
                    break;
                default:
                    break;
            }
            flag = false;
            bool b = KeyHook.UnHook(KeyHook.GetKeyHook);
            if (this.btnStartAndStop.Text == "结束")
            {
                KeyHook.Hook = KeyHook.SetHook(KeyHook.WH_KEYBOARD_LL, KeyHook.ChangeKey);
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 刷新界面
        /// </summary>
        private void RefreshControl()
        {
            this.label8.Focus();
            this.listView1.Items.Clear();
            foreach (KeyValuePair<int, int> kv in KeyConfig.DicKeys)
            {
                string[] sArray = new string[2];
                sArray[0] = ((Keys)kv.Key).ToString();
                sArray[1] = ((Keys)kv.Value).ToString();
                int[] iArray = new int[2];
                iArray[0] = kv.Key;
                iArray[1] = kv.Value;
                ListViewItem item = new ListViewItem(sArray);
                item.Tag = iArray;
                this.listView1.Items.Add(item);
            }
            this.txtAddOri.Text = "原按键";
            this.txtAddOri.Tag = -1;
            this.txtAddTar.Text = "目标按键";
            this.txtAddTar.Tag = -1;
            this.txtChangeOri.Text = "原按键";
            this.txtChangeOri.Tag = -1;
            this.txtChangeTar.Text = "目标按键";
            this.txtChangeTar.Tag = -1;
            KeyHook.GetKeyCode = -1;
            DictionarySerializer.Serialize(KeyConfig.cfgFilePath, KeyConfig.DicKeys);
        }
        #endregion
    }
}
