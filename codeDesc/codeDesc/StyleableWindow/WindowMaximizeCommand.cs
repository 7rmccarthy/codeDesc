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
                    window.IconSource = new ImageSourceConverter().ConvertFromString("../../Icons/Maximize_btn.png") as ImageSource;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                    window.IconSource = new ImageSourceConverter().ConvertFromString("../../Icons/RestoreWindow_btn.png") as ImageSource;
                    Console.WriteLine(window.IconSource);
                }               
            }           
        }

    }
}
