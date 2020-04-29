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
    public partial class TouchScreenListener : Form
    {
        DeviceData Device;
        public TouchScreenListener(DeviceData d, Size s)
        {
            InitializeComponent();
            Size = s;
            MinimumSize = s;
            MaximumSize = s;
            Device = d;
        }

        private void TouchScreenListener_Load(object sender, EventArgs e)
        {

        }

        private void TouchScreenListener_MouseClick(object sender, MouseEventArgs e)
        {
            int x = Cursor.Position.X - Location.X;
            int y = Cursor.Position.Y - Location.Y;
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand(string.Format("input tap {0} {1}", x*2, y*2), Device, receiver);
            Console.WriteLine(Device.Name + " says:\n \n" + receiver.ToString());
        }

        private void TouchScreenListener_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void TouchScreenListener_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void TouchScreenListener_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
