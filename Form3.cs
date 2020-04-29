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
    public partial class Form3 : Form
    {
        DeviceData Device;
        public Form3(DeviceData d)
        {
            InitializeComponent();
            Device = d;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("getprop ro.build.version.release", Device, receiver);
            string version = receiver.ToString();

            receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("dumpsys battery", Device, receiver);
            string battery = receiver.ToString();

            receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("dumpsys iphonesybinfo", Device, receiver);
            string imei = receiver.ToString();

            receiver = new ConsoleOutputReceiver();
            AdbClient.Instance.ExecuteRemoteCommand("pm list features", Device, receiver);
            string features = receiver.ToString();

            label1.Text = string.Format("Device info\nName: {0}\nModel: {1}\nProduct: {2}\nSerial: {3}" +
                "\nMessage: {4}\nFeatures: {5}\nUSB: {6}\nTransportID: {7}\nState: {8}\nAndroid version: {9}\n{10}\nIMEI: {11}\nFeatures:\n\n{12}\n\n", Device.Name, Device.Model, Device.Product, Device.Serial, 
                Device.Message, Device.Features, Device.Usb, Device.TransportId, Device.State.ToString(), version, battery, imei, features);
        }
    }
}
