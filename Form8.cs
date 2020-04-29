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
    public partial class Form8 : Form
    {
        DeviceData Device;
        bool Playing = false;
        public Form8(DeviceData d)
        {
            InitializeComponent();
            Device = d;
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AdbClient.Instance.ExecuteRemoteCommand("input keyevent 88", Device, null);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AdbClient.Instance.ExecuteRemoteCommand("input keyevent 85", Device, null);
            if (Playing)
            {
                button2.Image = Properties.Resources.baseline_pause_black_48dp;
            }
            else
            {
                button2.Image = Properties.Resources.baseline_play_arrow_black_48dp;
            }
            Playing = !Playing;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AdbClient.Instance.ExecuteRemoteCommand("input keyevent 87", Device, null);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AdbClient.Instance.ExecuteRemoteCommand("input keyevent 89", Device, null);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            AdbClient.Instance.ExecuteRemoteCommand("input keyevent 86", Device, null);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            AdbClient.Instance.ExecuteRemoteCommand("input keyevent 90", Device, null);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            AdbClient.Instance.ExecuteRemoteCommand("input keyevent 25", Device, null);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            AdbClient.Instance.ExecuteRemoteCommand("input keyevent 164", Device, null);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            AdbClient.Instance.ExecuteRemoteCommand("input keyevent 24", Device, null);
        }
    }
}
