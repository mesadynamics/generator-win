using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Amnesty_Generator
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}