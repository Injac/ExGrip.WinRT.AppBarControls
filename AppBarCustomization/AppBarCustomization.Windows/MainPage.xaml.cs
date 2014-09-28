using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AppBarCustomization
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private TestCommand cmd;
        public TestCommand Cmd
        {
            get
            {
                return cmd;
            }

            set
            {
                cmd = value;
            }
        }

        ToggleCommandBarCommand cmdBar;
        public ToggleCommandBarCommand ToggleCommand
        {
            get
            {
                return cmdBar;
            }

            set
            {
                cmdBar = value;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            this.Cmd = new TestCommand();
            this.ToggleCommand = new ToggleCommandBarCommand();
            this.DataContext = this;
        }

        private async void secondButton_LeftAreaButtonClicked(object s, EventArgs e)
        {
            MessageDialog d = new MessageDialog("Hello World from Event", "Message");
            await d.ShowAsync();
        }

        private bool collapsed = true;
        private void secondButton_ToggleAreaButtonClicked(object s, EventArgs e)
        {
            if (collapsed)
            {
                testbtn.Visibility = Visibility.Visible;
            }

            else
            {
                testbtn.Visibility = Visibility.Collapsed;
            }

            collapsed = !collapsed;
        }
    }
}
