using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReadHddSn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGetSerial_Click(object sender, RoutedEventArgs e)
        {
            var computerHddSn = GetHddSerial();
            TxtDisplay.Text = computerHddSn;
        }

        private static string GetHddSerial()
        {
            var hddList = new StringBuilder();
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            
            foreach (ManagementObject info in searcher.Get())
            {
                hddList.Append(info["SerialNumber"]);
                hddList.Append(" *** ");
            }

            return hddList.ToString();
        }

        private void BtnCopyClipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TxtDisplay.Text);
        }
    }
}
