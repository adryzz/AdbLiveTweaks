using SharpAdbClient;
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

namespace AdbLiveTweaks
{
    public partial class Form11 : Form
    {
        DeviceData Device;
        public Form11(DeviceData d)
        {
            InitializeComponent();
            Device = d;
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("dumpsys battery set level " + numericUpDown1.Value, Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            if (checkBox1.Checked)
            {
                AdbClient.Instance.ExecuteRemoteCommand("dumpsys battery set ac 1" + numericUpDown1.Value, Device, receiver);
            }
            else
            {
                AdbClient.Instance.ExecuteRemoteCommand("dumpsys battery set ac 0" + numericUpDown1.Value, Device, receiver);
            }
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            if (checkBox2.Checked)
            {
                AdbClient.Instance.ExecuteRemoteCommand("dumpsys battery set usb 1" + numericUpDown1.Value, Device, receiver);
            }
            else
            {
                AdbClient.Instance.ExecuteRemoteCommand("dumpsys battery set usb 0" + numericUpDown1.Value, Device, receiver);
            }
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            if (checkBox3.Checked)
            {
                AdbClient.Instance.ExecuteRemoteCommand("dumpsys battery set wireless 1" + numericUpDown1.Value, Device, receiver);
            }
            else
            {
                AdbClient.Instance.ExecuteRemoteCommand("dumpsys battery set wireless 0" + numericUpDown1.Value, Device, receiver);
            }
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("dumpsys battery reset", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }
    }
}
