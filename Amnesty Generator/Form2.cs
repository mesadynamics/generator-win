using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Amnesty_Generator
{
    public partial class Form2 : Form
    {
        bool ready = false;
        string readyString = null;
        string imageFile = null;

        public Form2(string s)
        {
            InitializeComponent();

            readyString = s;

            string tempFile = Path.GetTempFileName();
            imageFile = tempFile.Replace(".tmp", ".png");

            Bitmap image = Amnesty_Generator.Properties.Resources.HelpImage;
            image.Save(imageFile);

            string html = Amnesty_Generator.Properties.Resources.Help;
            string localHtml = html.Replace("../Icon.png", imageFile);

            webBrowser1.DocumentText = localHtml;
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        public void ShowHelp(string s)
        {
            if(ready)
                webBrowser1.Document.InvokeScript("ShowHelp", new string[] { s });
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
             this.Visible = false;
             e.Cancel = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (ready == false)
            {
                File.Delete(imageFile);

                if(readyString != null)
                    webBrowser1.Document.InvokeScript("ShowHelp", new string[] { readyString });

                readyString = null;
                ready = true;
            }
        }
    }
}