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
    public partial class Form6 : Form
    {
        DeviceData Device;
        public Form6(DeviceData d)
        {
            InitializeComponent();
            Device = d;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
