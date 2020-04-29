using SharpAdbClient;
using SharpAdbClient.DeviceCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdbLiveTweaks
{
    public partial class Form4 : Form
    {
        DeviceData Device;
        IProgress<int> Progress;
        public Form4(DeviceData d)
        {
            InitializeComponent();
            Device = d;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Progress = new Progress<int>(ProgressChanged);
        }

        private void ProgressChanged(int val)
        {
            progressBar1.Value = val;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var file = openFileDialog1.ShowDialog();
            if (file == DialogResult.OK)
            {
                string filePath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                new Thread(new ThreadStart(() =>
                {
                    using (SyncService service = new SyncService(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)), Device))
                    using (Stream stream = File.OpenRead(filePath))
                    {
                        service.Push(stream, filePath, 444, DateTime.Now, Progress, CancellationToken.None);
                    }
                })).Start();
                
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var file = saveFileDialog1.ShowDialog();
            if (file == DialogResult.OK)
            {
                string filePath = saveFileDialog1.InitialDirectory + saveFileDialog1.FileName;
                new Thread(new ThreadStart(() =>
                {
                    using (SyncService service = new SyncService(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)), Device))
                    using (Stream stream = File.OpenWrite(filePath))
                    {
                        service.Pull(filePath, stream, Progress, CancellationToken.None);
                    }
                })).Start();

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var file = openFileDialog1.ShowDialog();
            if (file == DialogResult.OK)
            {
                string filePath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                PackageManager manager = new PackageManager(Device);
                manager.InstallPackage(filePath, reinstall: false);
            }
        }
    }
}
