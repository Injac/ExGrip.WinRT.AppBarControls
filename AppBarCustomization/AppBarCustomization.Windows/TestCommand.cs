using System;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppBarCustomization
{
    public class TestCommand : ICommand
    {
        public async void Execute(object parameter)
        {
            MessageDialog d = new MessageDialog(parameter as string,"Message");
            await d.ShowAsync();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }


    public class ToggleCommandBarCommand : ICommand
    {

        private bool collapse = false;

        public  void Execute(object parameter)
        {

            var stackPanel = parameter as StackPanel;

            if (collapse)
            {
                stackPanel.Visibility = Visibility.Collapsed;
            }

            else
            {
                stackPanel.Visibility = Visibility.Visible;
            }

            collapse = !collapse;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }

}
