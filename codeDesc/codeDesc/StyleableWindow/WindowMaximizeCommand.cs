using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace codeDesc.StyleableWindow
{
    public class WindowMaximizeCommand : ICommand
    {              
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var window = parameter as MainWindow;

            if (window != null)
            {
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                    window.IconSource = new ImageSourceConverter().ConvertFromString(@"C:\Users\maxi\Documents\Schule\Schule\codeDesc\codeDesc\codeDesc\codeDesc\Icons\Maximize_btn.png") as ImageSource;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                    window.IconSource = new ImageSourceConverter().ConvertFromString(@"C:\Users\maxi\Documents\Schule\Schule\codeDesc\codeDesc\codeDesc\codeDesc\Icons\RestoreWindow_btn.png") as ImageSource;
                    Console.WriteLine(window.IconSource);
                }               
            }           
        }

    }
}
