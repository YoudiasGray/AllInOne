using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;

namespace AutoCopy.ViewModel
{
    internal partial class ViewModel : ObservableObject
    {
        ///UI元素：一个按钮用来打开文件，一个文本框输入延时时间，一个开始按钮，一个文本框显示内容

        [ObservableProperty]
        private string fileName;

        [ObservableProperty]
        private int delayTime;

        [ObservableProperty]
        private string? content;

        [RelayCommand]
        private void SelectFile()
        {
            // 打开一个文本文件选择对话框，选择文件后将文件内容设置给content
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if(openFileDialog.ShowDialog() == true )
            {
                string fileName = openFileDialog.FileName;
                content = File.ReadAllText(fileName);
            }

        }


        [RelayCommand]
        private void StartCopy()
        {
            if(delayTime<=0 || delayTime > 10000)
            {
                delayTime = 5;
            }
            Thread.Sleep(delayTime);

            // 每次读取150字节，然后复制粘贴
            int i = 0;
            while(i+150<=content.Length)
            {
                // 
            }            
        }
        private void Paste()
        {
            // 按下control+V
            //RoutedCommand routedCommand = new RoutedCommand();

            //routedCommand.InputGestures.Add(new KeyGesture(Key.V, ModifierKeys.Control));

            //routedCommand.Execute(null,tar)
            SendKeys.SendWait("^v");

        }
        
    }
}
