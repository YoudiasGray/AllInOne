using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Clipboard = System.Windows.Clipboard;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace AutoCopy_framwork
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                FileName.Content = fileName;
                Content.Text = File.ReadAllText(fileName);
            }
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int time = 5;
            if (int.TryParse(Content.Text, out time) is false)
            {
                time = 5;
            }
            Thread.Sleep(time * 1000);
            string tmpStr = "";
            int index = 0;
            int length = 150;
            string content = Content.Text;
            while (index < content.Length)
            {
                if (index + length <= content.Length)
                {
                    tmpStr = content.Substring(index, length);
                }
                else
                {
                    tmpStr = content.Substring(index);
                }
                try
                {
                    //Clipboard.SetText(tmpStr);
                    Clipboard.SetDataObject(tmpStr);
                    Paste();                    
                    Thread.Sleep(200);
                    
                }
                catch (Exception ex)
                {
                    Clipboard.SetDataObject(tmpStr, true);
                    //Clipboard.SetText(tmpStr);
                    Paste();
                    Thread.Sleep(200);
                }
                finally
                {
                    index += length;
                    Clipboard.Clear();
                }
            }
            System.Windows.MessageBox.Show("OK");
        }

        private void Paste()
        {
            SendKeys.SendWait("^v");
        }

        private void Button_Click_clear(object sender, RoutedEventArgs e)
        {
            Content.Text = "";
        }

        private void Button_Click_start(object sender, RoutedEventArgs e)
        {
            //Thread.Sleep(10 * 1000);
            //SendKeys.SendWait("^v");
            Button_Click_2(sender, e);
        }

        private void Button_chosefile(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e);
        }
    }
}
