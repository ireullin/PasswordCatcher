using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace WindowsFormsApplication1
{
    public class Win32API
    {
        public const int GWL_STYLE = -16;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const uint EM_SETPASSWORDCHAR = 204;
        public const uint WM_SETTEXT = 0x0c;
        public const uint WM_GETTEXT = 0x0d;
        public const uint HTCAPTION = 2;
        public const long ES_PASSWORD = 0x0020;
        

        [DllImport("user32")]
        public static extern int GetCursorPos(ref System.Drawing.Point lpPoint);

        [DllImport("user32")]
        public static extern int WindowFromPoint(int x, int y);

        [DllImport("user32")]
        public static extern int GetClassName(int hwnd, StringBuilder lpClassName, int size);

        [DllImport("user32")]
        public static extern int GetWindowLong(int hwnd, int nIndex);

        [DllImport("user32")]
        public static extern int SendMessage(int hwnd, uint msg, uint wParam, StringBuilder lParam);

        [DllImport("user32")]
        public static extern int PostMessage(int hwnd, uint msg, uint wParam, uint lParam);
    }
}
