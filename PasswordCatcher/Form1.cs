using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form, IMessageFilter
    {
        Point m_point = new Point();
        StringBuilder m_sbClass = new StringBuilder(255);
        StringBuilder m_sbContext = new StringBuilder(255);

        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Win32API.GetCursorPos(ref m_point);
            int _hwnd = Win32API.WindowFromPoint(m_point.X, m_point.Y);
            textBox1.Text = string.Format("hwnd:{2}  X:{0}  Y:{1}", m_point.X, m_point.Y, _hwnd);

            Win32API.GetClassName(_hwnd, m_sbClass, 255);
            textBox2.Text = m_sbClass.ToString();

            long _style = Win32API.GetWindowLong(_hwnd, Win32API.GWL_STYLE);
            long _cmp = _style & Win32API.ES_PASSWORD;
            if (_cmp != 0)
            {
                Win32API.PostMessage(_hwnd, Win32API.EM_SETPASSWORDCHAR, 0, 0);
                Win32API.SendMessageA(_hwnd, Win32API.WM_GETTEXT, 255, m_sbContext);
                
                if(!checkBox1.Checked)
                    Win32API.PostMessage(_hwnd, Win32API.EM_SETPASSWORDCHAR, 42, 0); // 42 means ascii *
            }
            else
            {
                Win32API.SendMessageA(_hwnd, Win32API.WM_GETTEXT, 255, m_sbContext);
            }
            

            textBox3.Text = m_sbContext.ToString();
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg==Win32API.WM_LBUTTONDOWN)
                Win32API.SendMessageB(this.Handle.ToInt32(), Win32API.WM_NCLBUTTONDOWN, Win32API.HTCAPTION, 0);
            else
                Win32API.SendMessageB(this.Handle.ToInt32(), m.Msg, m.WParam.ToInt32(), m.LParam.ToInt32() );

            return false;
        }

    }
}

