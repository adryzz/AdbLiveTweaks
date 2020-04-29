using SharpAdbClient;
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
    public partial class Form10 : Form
    {
        DeviceData Device;
        public Form10(DeviceData d)
        {
            InitializeComponent();
            Device = d;
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AdbClient.Instance.ExecuteRemoteCommand("screencap /sdcard/screencap.png", Device, null);
            string filePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";

            using (SyncService service = new SyncService(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)), Device))
            {
                Stream stream = File.OpenWrite(filePath);
                Thread.Sleep(20);
                service.Pull(filePath, stream, null, CancellationToken.None);
                stream.Dispose();
            }
            pictureBox1.Image = Image.FromFile(filePath);
        }


        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Form10_Resize(object sender, EventArgs e)
        {
            //hard work
            panel1.Bounds = new Rectangle(panel1.Bounds.X, panel1.Bounds.Y, Width - 40, Height - 93);
            button1.Width = (Width / 2) - 26;
            button2.Width = (Width / 2) - 26;
            button2.Location = new Point((Width - 26) - button2.Width, button2.Location.Y);
        }
    }
}
