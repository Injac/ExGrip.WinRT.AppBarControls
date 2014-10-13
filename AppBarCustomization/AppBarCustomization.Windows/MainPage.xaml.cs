using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace AppBarCustomization 
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage 
    {
        private bool _collapsed = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            Cmd = new TestCommand();
            ToggleCommand = new ToggleCommandBarCommand();
            DataContext = this;
        }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>The command.</value>
        public TestCommand Cmd { get; set; }

        /// <summary>
        /// Gets or sets the toggle command.
        /// </summary>
        /// <value>The toggle command.</value>
        public ToggleCommandBarCommand ToggleCommand { get; set; }

        /// <summary>
        /// Handles the LeftAreaButtonClicked event of the SecondButton control.
        /// </summary>
        /// <param name="s">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void SecondButton_LeftAreaButtonClicked(object s, EventArgs e)
        {
            var messageDialog  = new MessageDialog("Hello World from Event", "Message");
            await messageDialog.ShowAsync();
        }

        /// <summary>
        /// Handles the ToggleAreaButtonClicked event of the SecondButton control.
        /// </summary>
        /// <param name="s">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SecondButton_ToggleAreaButtonClicked(object s, EventArgs e)
        {
            testbtn.Visibility = _collapsed ? Visibility.Visible : Visibility.Collapsed;
            _collapsed = !_collapsed;
        }
    }
}
