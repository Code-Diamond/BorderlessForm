using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorderlessForm
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int WS_EX_TRANSPARENT = 0x20;
        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;

        public Form1()
        {
            InitializeComponent();

            SetWindowLong(this.Handle, GWL_EXSTYLE, (IntPtr)(GetWindowLong(this.Handle, GWL_EXSTYLE) ^ WS_EX_LAYERED ^ WS_EX_TRANSPARENT));
            //SetLayeredWindowAttributes(this.Handle, 0, 0, LWA_ALPHA); // set transparency to 50% (128)
            this.TopMost = true; // put it on top
            
            Bounds = Screen.PrimaryScreen.Bounds;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;


            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;

            Label label = new Label();
            label.Text = "Hello World";
            label.Location = new Point(3000, 2000);//4k monitor
            label.AutoSize = true;
            label.Font = new Font("Consolas", 90);
            label.ForeColor = Color.DarkRed;
            label.Padding = new Padding(0);
            this.Controls.Add(label);
        }

    }
}
