using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpAdbClient;
using SharpAdbClient.DeviceCommands;

namespace AdbLiveTweaks
{
    public partial class Form1 : Form
    {
        DeviceData Device;
        DeviceMonitor Monitor = new DeviceMonitor(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)));
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Monitor.DeviceConnected += Monitor_DeviceConnected;
            Monitor.DeviceDisconnected += Monitor_DeviceDisconnected;
            Monitor.DeviceChanged += Monitor_DeviceChanged;
        }

        private void Monitor_DeviceChanged(object sender, DeviceDataEventArgs e)
        {
            //MessageBox.Show(string.Format("{0} has been changed unexpectedly", e.Device.Name), "AdbLiveTweaks", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Monitor_DeviceDisconnected(object sender, DeviceDataEventArgs e)
        {
            if (Device.Equals(e.Device))
            {
                MessageBox.Show(string.Format("{0} has been disconnected unexpectedly", e.Device.Name), "AdbLiveTweaks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke(new EnableButtonsDelegate((s) =>
                {
                    button2.Enabled = s;
                    button3.Enabled = s;
                    button4.Enabled = s;
                    button5.Enabled = s;
                    button6.Enabled = s;
                    button7.Enabled = s;
                    button8.Enabled = s;
                    button9.Enabled = s;
                    button10.Enabled = s;
                    button11.Enabled = s;
                }), false);
            }
            else
            {
                MessageBox.Show(string.Format("{0} has been disconnected unexpectedly", e.Device.Name), "AdbLiveTweaks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Monitor_DeviceConnected(object sender, DeviceDataEventArgs e)
        {
            var res = MessageBox.Show(string.Format("Found new device: {0}\nConnect to it?", e.Device.Name), "AdbLiveTweaks", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Device = e.Device;
                Invoke(new EnableButtonsDelegate((s) =>
                {
                    button2.Enabled = s;
                    button3.Enabled = s;
                    button4.Enabled = s;
                    button5.Enabled = s;
                    button6.Enabled = s;
                    button7.Enabled = s;
                    button8.Enabled = s;
                    button9.Enabled = s;
                    button10.Enabled = s;
                    button11.Enabled = s;
                }), true);
            }
            else
            {
                //don't do anything
            }
        }

        private delegate void EnableButtonsDelegate(bool value);

        private void Form1_Shown(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(() => { MessageBox.Show(new Form() { TopMost = true }, "Hello!\nThis is a powerful tool for advanced users, and allows them to perform a LOT of stuff.\nIn order to start, you need ADB installed and running\n(adb devices)\nFor more info and updates, go to 'https://github.com/adryzz/'", "AdbLiveTweaks", MessageBoxButtons.OK); })).Start();
            Monitor.Start();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog(this);
            if (f2.HasSelected)
            {
                Device = f2.GetDevice();
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
            }
            f2.Dispose();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(Device);
            f3.Show(this);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(Device);
            f4.Show(this);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(Device);
            f5.Show(this);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(Device);
            f6.Show(this);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(Device);
            f7.Show(this);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8(Device);
            f8.Show(this);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9(Device);
            f9.Show(this);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10(Device);
            f10.Show();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11(Device);
            f11.Show(this);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12(Device);
            f12.Show(this);
        }
    }
}
