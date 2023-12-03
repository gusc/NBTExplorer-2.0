﻿using System.Windows.Forms;

namespace NBTExplorer.Windows
{
    public partial class About : Form
    {
        public About ()
        {
            InitializeComponent();

            int len = linkLabel1.Text.Length;
            System.Version version = typeof(About).Assembly.GetName().Version;
            string versionNumber = version.Major + "." + version.Minor + "." + version.Build;
            if (version.Revision != 0)
            {
                versionNumber += "." + version.Revision;
            }

            linkLabel1.Text = linkLabel1.Text.Replace("{ver}", versionNumber);

            int adj = linkLabel1.Text.Length - len;
            linkLabel1.LinkArea = new LinkArea(linkLabel1.LinkArea.Start + adj, linkLabel1.LinkArea.Length);
        }

        private void linkLabel1_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.github.com/foxypiratecove37350/NBTExplorer-2.0");
        }
    }
}
