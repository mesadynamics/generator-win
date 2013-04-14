//
//  Amnesty Generator for Vista
//
//  Created by Danny Espinoza on 1/30/07.
//  Copyright 2007 Mesa Dynamics, LLC. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Amnesty_Generator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.Environment.OSVersion.Version.Major < 6)
            {
                MessageBox.Show("Sorry, Amnesty Generator requires Windows Vista to run.");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}