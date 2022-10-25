using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace HttpDownloader
{
    public partial class DownloadControl : UserControl
    {
        WebClient webClient=new WebClient();
        public event Action EndLoad;
        public string address { get; private set; }
        public string destination { get; private set; }
        public string Path { get; private set; }
        private ProgressBar progressbar;
        private Label progresslabel;
        private bool StopDownload = false;
        private bool PauseDownload = false;
        public DownloadControl(string address, string destination)
        {
            InitializeComponent();
            this.address = address;
            this.destination = destination;
            this.Width = 450;
            this.Height = 50;
            var addresslabel = new Label() { Margin = new Padding(5), Width = 200, Text=address };
            this.Controls.Add(addresslabel);
            var progress = new ProgressBar() {Margin=new Padding(5), Left = addresslabel.Width, Width = 100, Maximum=100, Minimum=0, Value=0};
            progressbar = progress;
            this.Controls.Add(progress);
            var label = new Label() { Margin = new Padding(5), Left = progress.Left+progress.Width, Width = 50, Text="0%" };
            progresslabel = label;
            this.Controls.Add(label);
            var cancel = new Button() { Margin = new Padding(5), Text = "Stop", Left = label.Left+label.Width, Width=50};
            cancel.Click += Stop;
            this.Controls.Add(cancel);
            var pause = new Button() { Margin = new Padding(5), Text = "Pause", Left = cancel.Left+cancel.Width, Width=50};
            pause.Click += Pause;
            this.Controls.Add(pause);
        }
        

        private void Stop(object sender, EventArgs ea)
        {
            PauseDownload = true;
            StopDownload = true;
        }

        private void Pause(object sender, EventArgs ea)
        {
            if((sender as Button).Text=="Pause")
            {
                (sender as Button).Text = "Resume";
                PauseDownload = true;
                progressbar.SetState(3);
            }
            else
            {
                (sender as Button).Text = "Pause";
                PauseDownload = false;
                progressbar.SetState(1);
            }
        }

        public void StartDownload()
        {
            Task.Run(StartDownloadSync);
        }

        private void StartDownloadSync()
        {
            try
            {
                using (var stream = webClient.OpenRead(address))
                {
                    long len = long.Parse(webClient.ResponseHeaders["Content-Length"]);
                    string ext = webClient.ResponseHeaders["Content-Type"].Substring(webClient.ResponseHeaders["Content-Type"].LastIndexOf('/')+1);
                    long readbytes=0;
                    using (MemoryStream ms=new MemoryStream())
                    {
                        while (!StopDownload)
                        {
                            int bytes = 1;
                            while (!PauseDownload&&bytes!=0)
                            {
                                byte[] buff = new byte[1024];
                                bytes = stream.Read(buff, 0, buff.Length);
                                ms.Write(buff, 0, bytes);
                                readbytes += bytes;
                                this.Invoke(new Action(() =>
                                {
                                    progressbar.Value = (int)((readbytes * 1.0 / len) * 100);
                                    progresslabel.Text = $"{(int)((readbytes * 1.0 / len) * 100)}%";
                                }));                               
                            }
                            if(bytes==0)
                            {
                                byte[] res = ms.ToArray();
                                Save(res, destination, address, ext);
                                return;
                            }
                        }
                        MessageBox.Show($"Downloading of {address} stopped successfully.");
                        EndLoad?.Invoke();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured while downloading from {address}");
                EndLoad?.Invoke();
            }
        }

        private void Save(byte[] data, string path, string addr, string ext)
        {
            if (data == null)
            {
                MessageBox.Show($"An error occured while saving data downloaded from {addr}");
                EndLoad?.Invoke();
                return;
            }
            try
            {
                Path = path + $"\\file{new Random().Next()%3}"+ "." + ext;
                using (Stream stream = new FileStream(Path, FileMode.OpenOrCreate))
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            catch 
            {
                MessageBox.Show($"An error occured while saving data downloaded from {addr}");
                EndLoad?.Invoke();
                return;
            }
            MessageBox.Show($"Successfully downloaded from {addr}");
            EndLoad?.Invoke();
        }
    }
}
public static class ModifyProgressBarColor
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
    public static void SetState(this ProgressBar pBar, int state)
    {
        SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
    }
}
