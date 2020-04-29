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
    public partial class Form5 : Form
    {
        DeviceData Device;
        public Form5(DeviceData d)
        {
            InitializeComponent();
            Device = d;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("am start -a android.intent.action.CALL -d tel:" + textBox1.Text, Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("input keyevent 6", Device, receiver);
            MessageBox.Show(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
