using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpAdbClient;
using SharpAdbClient.DeviceCommands;

namespace AdbLiveTweaks
{
    public partial class Form2 : Form
    {
        DeviceData Device;
        List<DeviceData> Devices = new List<DeviceData>();
        public bool HasSelected = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach(DeviceData d in AdbClient.Instance.GetDevices())
            {
                Devices.Add(d);
                comboBox1.Items.Add(d.Name);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Devices.Clear();
            comboBox1.Items.Clear();
            foreach (DeviceData d in AdbClient.Instance.GetDevices())
            {
                Devices.Add(d);
                comboBox1.Items.Add(d.Name);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Device = Devices.ElementAt(comboBox1.SelectedIndex);
            HasSelected = true;
            Close();
        }

        public DeviceData GetDevice()
        {
            return Device;
        }
    }
}
