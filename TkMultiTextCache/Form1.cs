using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using gma.System.Windows;

namespace TkMultiTextCache
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        UserActivityHook actHook;
        bool IsAltDown = false;
        bool IsCtrlDown = false;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            actHook = new UserActivityHook();
            actHook.KeyDown += new KeyEventHandler(KeyDownEvent);
            actHook.KeyUp += new KeyEventHandler(KeyUpEvent);
            actHook.Start();
        }
        public void KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue) {
                case 220:
                    if (IsCtrlDown)
                    {
                        ShowWindow();
                    }
                    break;
                case 162:
                    IsCtrlDown = true;
                    break;
                case 164:
                    IsAltDown = true;
                    break;
                case 165:
                    IsCtrlDown = false;
                    IsAltDown = false;
                    break;
                case 49:
                    if (IsCtrlDown && textBox1.Text.Length > 0)
                    {
                        SetCache(textBox1.Text);
                    }
                    else if (IsAltDown && GetCache().Length > 0)
                    {
                        textBox1.Text = GetCache();
                    }
                    break;
                case 50:
                    if (IsCtrlDown && textBox2.Text.Length > 0)
                    {
                        SetCache(textBox2.Text);
                    }
                    else if (IsAltDown && GetCache().Length > 0)
                    {
                        textBox2.Text = GetCache();
                    }
                    break;
                case 51:
                    if (IsCtrlDown && textBox3.Text.Length > 0)
                    {
                        SetCache(textBox3.Text);
                    }
                    else if (IsAltDown && GetCache().Length > 0)
                    {
                        textBox3.Text = GetCache();
                    }
                    break;
                case 52:
                    if (IsCtrlDown && textBox4.Text.Length > 0)
                    {
                        SetCache(textBox4.Text);
                    }
                    else if (IsAltDown && GetCache().Length > 0)
                    {
                        textBox4.Text = GetCache();
                    }
                    break;
                case 53:
                    if (IsCtrlDown && textBox5.Text.Length > 0)
                    {
                        SetCache(textBox5.Text);
                    }
                    else if (IsAltDown && GetCache().Length > 0)
                    {
                        textBox5.Text = GetCache();
                    }
                    break;
                case 54:
                    if (IsCtrlDown && textBox6.Text.Length > 0)
                    {
                        SetCache(textBox6.Text);
                    }
                    else if (IsAltDown && GetCache().Length > 0)
                    {
                        textBox6.Text = GetCache();
                    }
                    break;
                case 55:
                    if (IsCtrlDown && textBox7.Text.Length > 0)
                    {
                        SetCache(textBox7.Text);
                    }
                    else if (IsAltDown && GetCache().Length > 0)
                    {
                        textBox7.Text = GetCache();
                    }
                    break;
                case 56:
                    if (IsCtrlDown && textBox8.Text.Length > 0)
                    {
                        SetCache(textBox8.Text);
                    }
                    else if (IsAltDown && GetCache().Length > 0)
                    {
                        textBox8.Text = GetCache();
                    }
                    break;
                case 57:
                    if (IsCtrlDown && textBox9.Text.Length > 0)
                    {
                        SetCache(textBox9.Text);
                    }
                    else if (IsAltDown && GetCache().Length > 0)
                    {
                        textBox9.Text = GetCache();
                    }
                    break;
            }
            if ((IsCtrlDown || IsAltDown) && e.KeyValue >= 47 && e.KeyValue <= 57)
            {
                e.Handled = true;
            }
        }
        public void KeyUpEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 220:
                    if (IsCtrlDown)
                    {
                        HideWindow();
                    }
                    break;
                case 162:
                    IsCtrlDown = false;
                    break;
                case 164:
                    IsAltDown = false;
                    break;
                case 165:
                    IsCtrlDown = false;
                    IsAltDown = false;
                    break;
            }
        }
        public string GetCache()
        {
            IDataObject iData = Clipboard.GetDataObject();
            return iData.GetData(System.Windows.Forms.DataFormats.StringFormat).ToString();
        }
        public void SetCache(string Text)
        {
            System.Windows.Forms.Clipboard.SetDataObject(Text, true);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://thomaskekeisen.de");
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideWindow();
            }
        }

        public void HideWindow()
        {
            this.Hide();
        }
        public void ShowWindow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2);
            this.BringToFront();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowWindow();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


 
    }
}
