using Microsoft.Azure.Devices.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DeviceSimulator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private const string ConnectionSting = "HostName=<>.azure-devices.net;DeviceId=<>;SharedAccessKey=<>";


        Random r = new Random();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeviceClient client = DeviceClient.CreateFromConnectionString(ConnectionSting);
            Data data = new Data(r.Next(0, 100));
            string strData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            byte[] binaryData = Encoding.UTF8.GetBytes(strData);
            Message message = new Message(binaryData);
            client.SendEventAsync(message);
        }
    }

    public class Data
    {
        private static int id;
        static Data()
        {
            id = 0;
        }
        public Data(int value)
        {
            DeviceName = "PC";
            Time = DateTime.Now;
            Id = id++;
        }
        int Id { get; set; }
        string DeviceName { get; set; }
        DateTime Time { get; set; }
        int Value { get; set; }
    }
}
