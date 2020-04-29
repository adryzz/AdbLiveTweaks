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
    public partial class Form12 : Form
    {
        DeviceData Device;
        public Form12(DeviceData d)
        {
            InitializeComponent();
            Device = d;
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("svc wifi enable", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("svc wifi disable", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("svc bluetooth enable", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("svc bluetooth disable", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("svc data enable", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("svc data disable", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("settings put secure location_providers_allowed gps,network", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("settings put secure location_providers_allowed ' '", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("svc nfc enable", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("svc nfc disable", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }
    }
}
