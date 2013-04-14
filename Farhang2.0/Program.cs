﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Farhang2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UnmanagedCode.disableSound();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
