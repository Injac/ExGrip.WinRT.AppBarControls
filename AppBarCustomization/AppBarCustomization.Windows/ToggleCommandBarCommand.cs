using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppBarCustomization
{
    /// <summary>
    /// The toggle command bar command.
    /// </summary>
    public class ToggleCommandBarCommand : ICommand 
    {
        private bool _collapse;

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Execute(object parameter) 
        {
            var stackPanel = parameter as StackPanel;
            if (stackPanel == null)
            {
                return;
            }
            stackPanel.Visibility = _collapse ? Visibility.Collapsed : Visibility.Visible;

            _collapse = !_collapse;
        }

        /// <summary>
        /// The can execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;
    }
}