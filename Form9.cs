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
    public partial class Form9 : Form
    {
        DeviceData Device;
        public Form9(DeviceData d)
        {
            InitializeComponent();
            Device = d;
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("wm density " + numericUpDown1.Value, Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("wm density reset", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand(string.Format("wm size {0}x{1}", numericUpDown2.Value, numericUpDown3.Value), Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("wm size reset", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var receiver = new ConsoleOutputReceiver();
                AdbClient.Instance.ExecuteRemoteCommand("settings put system accelerometer_rotation 0", Device, receiver);
                MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
            }
            else
            {
                var receiver = new ConsoleOutputReceiver();
                AdbClient.Instance.ExecuteRemoteCommand("settings put system accelerometer_rotation 1", Device, receiver);
                MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("settings put system user_rotation 0", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("settings put system user_rotation 1", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("settings put system user_rotation 2", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("settings put system user_rotation 3", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }
    }
}
