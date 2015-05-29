using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HookKey
{
    public partial class Form1 : Form
    {
        int WH_KEYBOARD_LL = 13;
        private Button m_SelectedButton;
        public Form1()
        {
            InitializeComponent();
            KeyConfig.Initialize();
            KeyConfig.LoadHashKeys();
            ChangeButonNames();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            this.btnNum1.Click += new EventHandler(ClickKey);
            this.btnNum2.Click += new EventHandler(ClickKey);
            this.btnNum4.Click += new EventHandler(ClickKey);
            this.btnNum5.Click += new EventHandler(ClickKey);
            this.btnNum7.Click += new EventHandler(ClickKey);
            this.btnNum8.Click += new EventHandler(ClickKey);

            //this.btnNum1.KeyUp += new KeyEventHandler(ButtonKeyUp);
            //this.btnNum2.KeyUp += new KeyEventHandler(ButtonKeyUp);
            //this.btnNum4.KeyUp += new KeyEventHandler(ButtonKeyUp);
            //this.btnNum5.KeyUp += new KeyEventHandler(ButtonKeyUp);
            //this.btnNum7.KeyUp += new KeyEventHandler(ButtonKeyUp);
            //this.btnNum8.KeyUp += new KeyEventHandler(ButtonKeyUp);

            this.btnNum1.KeyDown += new KeyEventHandler(ButtonKeyUp);
            this.btnNum2.KeyDown += new KeyEventHandler(ButtonKeyUp);
            this.btnNum4.KeyDown += new KeyEventHandler(ButtonKeyUp);
            this.btnNum5.KeyDown += new KeyEventHandler(ButtonKeyUp);
            this.btnNum7.KeyDown += new KeyEventHandler(ButtonKeyUp);
            this.btnNum8.KeyDown += new KeyEventHandler(ButtonKeyUp);

            this.label5.Focus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            KeyHook.Hook = KeyHook.SetHook(WH_KEYBOARD_LL, KeyHook.ChangeKey);
            this.btnStop.Enabled = true;
            this.btnStart.Enabled = false;

            this.label5.Focus();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bool b = KeyHook.UnHook(KeyHook.Hook);
            if (!b)
                MessageBox.Show("解钩失败了,我也不知道怎么办……");
            this.btnStop.Enabled = false;
            this.btnStart.Enabled = true;

            this.label5.Focus();
        }

        private void Form1_FormClosing(object sender, EventArgs e)
        {
            KeyHook.UnHook(KeyHook.Hook);
        }

        private void ClickKey(object sender, EventArgs e)
        {
            m_SelectedButton = sender as Button;
        }
        private void ButtonKeyUp(object sender, KeyEventArgs e)
        {
            if (!this.btnStart.Enabled)
            {
                MessageBox.Show("请先点击Stop停止改键");
                return;
            }
            KeyConfig.PickedKey = e.KeyCode;
            if (KeyConfig.HashKeys.Contains(e.KeyCode))
            {
                MessageBox.Show("已存在相同按键，请先做更改");
                return;
            }
            if (m_SelectedButton != null)
            {
                switch (m_SelectedButton.Name)
                {
                    case "btnNum1":
                        KeyConfig.KeyCfg.Num1 = (Keys)KeyConfig.PickedKey;
                        break;
                    case "btnNum2":
                        KeyConfig.KeyCfg.Num2 = (Keys)KeyConfig.PickedKey;
                        break;
                    case "btnNum4":
                        KeyConfig.KeyCfg.Num4 = (Keys)KeyConfig.PickedKey;
                        break;
                    case "btnNum5":
                        KeyConfig.KeyCfg.Num5 = (Keys)KeyConfig.PickedKey;
                        break;
                    case "btnNum7":
                        KeyConfig.KeyCfg.Num7 = (Keys)KeyConfig.PickedKey;
                        break;
                    case "btnNum8":
                        KeyConfig.KeyCfg.Num8 = (Keys)KeyConfig.PickedKey;
                        break;
                }
            }
            KeyConfig.RefreshConfig();
            ChangeButonNames();
            this.label5.Focus();
        }

        private void ChangeButonNames()
        {
            this.btnNum1.Text = KeyConfig.KeyCfg.Num1.ToString();
            this.btnNum2.Text = KeyConfig.KeyCfg.Num2.ToString();
            this.btnNum4.Text = KeyConfig.KeyCfg.Num4.ToString();
            this.btnNum5.Text = KeyConfig.KeyCfg.Num5.ToString();
            this.btnNum7.Text = KeyConfig.KeyCfg.Num7.ToString();
            this.btnNum8.Text = KeyConfig.KeyCfg.Num8.ToString();
        }
    }
}
