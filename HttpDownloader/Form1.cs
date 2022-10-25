using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace HttpDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DownloadBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if(folderBrowserDialog.ShowDialog()==DialogResult.OK)
            {
                var r = new DownloadControl(textBox1.Text, folderBrowserDialog.SelectedPath);
                r.EndLoad += () =>  { this.Invoke(new Action(() => { try { listView1.Controls.Remove(r); Downloaded.Items.Add(r.Path); } catch { } })); };
                listView1.Controls.Add(r);
                r.StartDownload();
            }
        }

        private void Downloaded_DoubleClick(object sender, EventArgs e)
        {
            if (Downloaded.SelectedIndices.Count > 0)
            {
                try
                {
                    Process.Start(Downloaded.SelectedItem.ToString());
                }catch
                {
                    Downloaded.Items.Remove(Downloaded.SelectedItem);
                }
            }
        }
    }
}
