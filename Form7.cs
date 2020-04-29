using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdbLiveTweaks
{
    public partial class Form7 : Form
    {
        DeviceData Device;
        public Form7(DeviceData d)
        {
            InitializeComponent();
            Device = d;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("wm size", Device, receiver);
            string data = receiver.ToString();
            data = data.Remove(0, 15);
            string[] vals = data.Split('x');
            TouchScreenListener l = new TouchScreenListener(Device, new Size(int.Parse(vals[0])/2, int.Parse(vals[1])/2));
            l.Show();
        }
    }
}
