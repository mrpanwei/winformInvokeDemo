using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace gmWeight
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form fl = new login();
            fl.ShowDialog();
            if (fl.DialogResult == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            else
            {
                return;
            } 
        }
    }
}
