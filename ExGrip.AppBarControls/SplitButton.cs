using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using System.Windows.Input;

namespace ExGrip.AppBarControls 
{
    /// <summary>
    /// Delegate LeftAreaClicked
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void LeftAreaClicked(object s, EventArgs e);

    /// <summary>
    /// Delegate ToggleAreaClicked
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void ToggleAreaClicked(object s, EventArgs e);

    /// <summary>
    /// Define the split button.
    /// </summary>
    [TemplatePart(Name = "PART_ToggleThumb", Type = typeof(Border))]
    [TemplatePart(Name = "PART_LeftArea", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_RightArea", Type = typeof(Grid))]
    public class SplitButton : Control 
    {
        private Grid _leftArea;
        private Grid _rightArea;
        private Border _thumb;
        private event LeftAreaClicked leftAreaButtonClicked;
        private event ToggleAreaClicked toggleAreaButtonClicked;

        /// <summary>
        /// The caption property.
        /// Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty CaptionProperty = 
            DependencyProperty.Register("Caption", typeof(string), typeof(SplitButton), new PropertyMetadata("Caption"));

        /// <summary>
        /// The left area background property.
        /// Using a DependencyProperty as the backing store for LeftAreaBackground.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty LeftAreaBackgroundProperty =
            DependencyProperty.Register("LeftAreaBackground", typeof(Brush), typeof(SplitButton), new PropertyMetadata(null));

        /// <summary>
        /// The left area mouse down command parameter property.
        /// Using a DependencyProperty as the backing store for RightAreaMouseDownCommandParameter.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty LeftAreaMouseDownCommandParameterProperty =
            DependencyProperty.Register("LeftAreaMouseDownCommandParameter", typeof(object), typeof(SplitButton), new PropertyMetadata(null));

        /// <summary>
        /// The left area mouse down command property.
        /// Using a DependencyProperty as the backing store for RightAreaMouseDownCommand.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty LeftAreaMouseDownCommandProperty =
            DependencyProperty.Register("LeftAreaMouseDownCommand", typeof(ICommand), typeof(SplitButton), new PropertyMetadata(null));
        
        /// <summary>
        /// The right area background property.
        /// Using a DependencyProperty as the backing store for RightAreaBackground.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty RightAreaBackgroundProperty =
            DependencyProperty.Register("RightAreaBackground", typeof(Brush), typeof(SplitButton), new PropertyMetadata(null));

        /// <summary>
        /// The right toggle property.
        /// Using a DependencyProperty as the backing store for RightToggle.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty RightToggleProperty =
            DependencyProperty.Register("RightToggle", typeof(bool), typeof(SplitButton), new PropertyMetadata(null));

        /// <summary>
        /// The thumb fill property.
        ///  Using a DependencyProperty as the backing store for ThumbFill.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty ThumbFillProperty =
            DependencyProperty.Register("ThumbFill", typeof(Brush), typeof(SplitButton), new PropertyMetadata(null));

        /// <summary>
        /// The toggle area visibility property.
        /// Using a DependencyProperty as the backing store for ToggleAreaVisibility.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty ToggleAreaVisibilityProperty =
            DependencyProperty.Register("ToggleAreaVisibility", typeof(Visibility), typeof(SplitButton), new PropertyMetadata(default(Visibility), RightAreaVisibilityChanged)
                                       );
        /// <summary>
        /// The toggle button clicked command parameter property.
        /// Using a DependencyProperty as the backing store for ToggleButtonClickedCommandParameter.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty ToggleButtonClickedCommandParameterProperty =
            DependencyProperty.Register("ToggleButtonClickedCommandParameter", typeof(object), typeof(SplitButton), new PropertyMetadata(null));

        /// <summary>
        /// The toggle button clicked command property.
        /// Using a DependencyProperty as the backing store for ToggleButtonClickedCommand.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty ToggleButtonClickedCommandProperty =
            DependencyProperty.Register("ToggleButtonClickedCommand", typeof(ICommand), typeof(SplitButton), new PropertyMetadata(null));

        /// <summary>
        /// The toggle on parent focus change property.
        /// Using a DependencyProperty as the backing store for ToggleOnParentFocusChange.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty ToggleOnParentFocusChangeProperty =
            DependencyProperty.Register("ToggleOnParentFocusChange", typeof(bool), typeof(SplitButton), new PropertyMetadata(false));
        
        /// <summary>
        /// The top image property.
        /// Using a DependencyProperty as the backing store for TopImage.  This enables animation, styling, binding, etc.
        /// </summary>
        public static readonly DependencyProperty TopImageProperty =
            DependencyProperty.Register("TopImage", typeof(ImageSource), typeof(SplitButton), new PropertyMetadata(null));
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SplitButton"/> class.
        /// </summary>
        public SplitButton()
        {
            DefaultStyleKey = typeof(SplitButton);
            MinWidth = 170;
            MinHeight = 100;
        }

        /// <summary>
        /// Occurs when [left area button clicked].
        /// </summary>
        public event LeftAreaClicked LeftAreaButtonClicked
        {
            add
            {
                leftAreaButtonClicked += value;
            }

            remove
            {
                leftAreaButtonClicked -= value;
            }
        }

        /// <summary>
        /// Occurs when [toggle area button clicked].
        /// </summary>
        public event ToggleAreaClicked ToggleAreaButtonClicked
        {
            add
            {
                toggleAreaButtonClicked += value;
            }
            remove
            {
                toggleAreaButtonClicked -= value;
            }
        }
        
        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption
        {
            get
            {
                return (string)GetValue(CaptionProperty);
            }

            set
            {
                SetValue(CaptionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the left area background.
        /// </summary>
        /// <value>The left area background.</value>
        public Brush LeftAreaBackground
        {
            get
            {
                return (Brush)GetValue(LeftAreaBackgroundProperty);
            }

            set
            {
                SetValue(LeftAreaBackgroundProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the left area mouse down command.
        /// </summary>
        /// <value>The left area mouse down command.</value>
        public ICommand LeftAreaMouseDownCommand
        {
            get
            {
                return (ICommand)GetValue(LeftAreaMouseDownCommandProperty);
            }
            set
            {
                SetValue(LeftAreaMouseDownCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the left area mouse down command parameter.
        /// </summary>
        /// <value>The left area mouse down command parameter.</value>
        public object LeftAreaMouseDownCommandParameter
        {
            get
            {
                return GetValue(LeftAreaMouseDownCommandParameterProperty);
            }
            set
            {
                SetValue(LeftAreaMouseDownCommandParameterProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the right area background.
        /// </summary>
        /// <value>The right area background.</value>
        public Brush RightAreaBackground
        {
            get
            {
                return (Brush)GetValue(RightAreaBackgroundProperty);
            }
            set
            {
                SetValue(RightAreaBackgroundProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [right toggle].
        /// </summary>
        /// <value><c>true</c> if [right toggle]; otherwise, <c>false</c>.</value>
        public bool RightToggle
        {
            get 
            {
                return (bool)GetValue(RightToggleProperty);
            }
            set 
            {
                SetValue(RightToggleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the thumb fill.
        /// </summary>
        /// <value>The thumb fill.</value>
        public Brush ThumbFill
        {
            get
            {
                return (Brush)GetValue(ThumbFillProperty);
            }
            set
            {
                SetValue(ThumbFillProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the toggle area visibility.
        /// </summary>
        /// <value>The toggle area visibility.</value>
        public Visibility ToggleAreaVisibility
        {
            get
            {
                return (Visibility)GetValue(ToggleAreaVisibilityProperty);
            }
            set
            {
                SetValue(ToggleAreaVisibilityProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the toggle button clicked command.
        /// </summary>
        /// <value>The toggle button clicked command.</value>
        public ICommand ToggleButtonClickedCommand
        {
            get
            {
                return (ICommand)GetValue(ToggleButtonClickedCommandProperty);
            }
            set
            {
                SetValue(ToggleButtonClickedCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the toggle button clicked command parameter.
        /// </summary>
        /// <value>The toggle button clicked command parameter.</value>
        public object ToggleButtonClickedCommandParameter
        {
            get
            {
                return GetValue(ToggleButtonClickedCommandParameterProperty);
            }
            set
            {
                SetValue(ToggleButtonClickedCommandParameterProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [toggle on parent focus change].
        /// </summary>
        /// <value><c>true</c> if [toggle on parent focus change]; otherwise, <c>false</c>.</value>
        public bool ToggleOnParentFocusChange
        {
            get 
            {
                return (bool)GetValue(ToggleOnParentFocusChangeProperty);
            }
            set 
            {
                SetValue(ToggleOnParentFocusChangeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the top image.
        /// </summary>
        /// <value>The top image.</value>
        public ImageSource TopImage
        {
            get 
            {
                return (ImageSource)GetValue(TopImageProperty);
            }
            set 
            {
                SetValue(TopImageProperty, value);
            }
        }

        /// <summary>
        /// Invoked whenever application code or internal processes (such as a rebuilding layout pass) 
        /// call ApplyTemplate. In simplest terms, this means the method is called just before a UI element
        /// displays in your app. Override this method to influence the default post-template logic of a 
        /// class.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            _thumb = GetTemplateChild("PART_ToggleThumb") as Border;
            _leftArea = GetTemplateChild("PART_LeftArea") as Grid;
            _rightArea = GetTemplateChild("PART_RightArea") as Grid;

            if (_leftArea != null)
            {
                _leftArea.PointerPressed += LeftArea_PointerPressed;
                _leftArea.PointerReleased += LeftArea_PointerReleased;
                _leftArea.PointerEntered += LeftArea_PointerEntered;
                _leftArea.PointerExited += LeftArea_PointerExited;
            }

            if (_rightArea != null)
            {
                _rightArea.PointerPressed += RightArea_PointerPressed;
                _rightArea.PointerReleased += RightArea_PointerReleased;
                _rightArea.PointerEntered += RightArea_PointerEntered;
                _rightArea.PointerExited += RightArea_PointerExited;
            }

            LostFocus += SplitButton_LostFocus;

            if (Parent is FrameworkElement)
            {
                var parent = Parent as FrameworkElement;

                if (ToggleOnParentFocusChange)
                {
                    parent.LostFocus += Parent_LostFocus;
                }
                else
                {
                    parent.LostFocus -= Parent_LostFocus;
                }
            }
            
            ToggleAreaVisibility = ToggleAreaVisibility;

            base.OnApplyTemplate();
        }

        /// <summary>
        /// Rights the area visibility changed.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void RightAreaVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d!=null) 
            {
                var controlInstance = d as SplitButton;

                if (controlInstance != null)
                {
                    var grid = controlInstance.GetTemplateChild("PART_LeftArea") as Grid;

                    if (grid != null) 
                    {
                        if (e.NewValue != null) 
                        {
                            if (((Visibility)e.NewValue) == Visibility.Collapsed) 
                            {
                                grid.SetValue(Grid.ColumnSpanProperty, 2);

                                var parentGrid = grid.Parent as Grid;

                                if (parentGrid != null) 
                                {
                                    grid.InvalidateMeasure();
                                    parentGrid.InvalidateMeasure();
                                }
                            }
                            else 
                            {
                                grid.SetValue(Grid.ColumnSpanProperty, 1);

                                var parentGrid = grid.Parent as Grid;

                                if (parentGrid != null) 
                                {
                                    grid.InvalidateMeasure();
                                    parentGrid.InvalidateMeasure();
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the PointerEntered event of the LeftArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Windows.UI.Xaml.Input.PointerRoutedEventArgs"/> instance containing the event data.</param>
        private void LeftArea_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "LeftAreaHover", true);
        }

        /// <summary>
        /// Handles the PointerExited event of the LeftArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Windows.UI.Xaml.Input.PointerRoutedEventArgs"/> instance containing the event data.</param>
        private void LeftArea_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "LeftAreaHoverOut", true);
        }

        /// <summary>
        /// Handles the PointerPressed event of the LeftArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Windows.UI.Xaml.Input.PointerRoutedEventArgs"/> instance containing the event data.</param>
        private void LeftArea_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "LeftAreaMouseDown", true);

            if (leftAreaButtonClicked != null)
            {
                leftAreaButtonClicked.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Handles the PointerReleased event of the LeftArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Windows.UI.Xaml.Input.PointerRoutedEventArgs"/> instance containing the event data.</param>
        private void LeftArea_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "LeftAreaMouseUp", true);

            if (LeftAreaMouseDownCommand != null)
            {
                LeftAreaMouseDownCommand.Execute(LeftAreaMouseDownCommandParameter);
            }
        }

        /// <summary>
        /// Handles the LostFocus event of the Parent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Parent_LostFocus(object sender, RoutedEventArgs e)
        {
           RightToggle = false;
           VisualStateManager.GoToState(this, "RightAreaHoverOut", true);
        }

        /// <summary>
        /// Handles the PointerEntered event of the RightArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Windows.UI.Xaml.Input.PointerRoutedEventArgs"/> instance containing the event data.</param>
        private void RightArea_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, !RightToggle ? "RightAreaHover" : "RightHoverToggle", true);
        }

        /// <summary>
        /// Handles the PointerExited event of the RightArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Windows.UI.Xaml.Input.PointerRoutedEventArgs"/> instance containing the event data.</param>
        private void RightArea_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, !RightToggle ? "RightAreaHoverOut" : "RightToggle", true);
        }

        /// <summary>
        /// Handles the PointerPressed event of the RightArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Windows.UI.Xaml.Input.PointerRoutedEventArgs"/> instance containing the event data.</param>
        private void RightArea_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, RightToggle ? "RightAreaMouseDown" : "RightAreaHoover", true);
            
            if (toggleAreaButtonClicked != null)
            {
                toggleAreaButtonClicked.Invoke(this, new EventArgs());
            }

            if (ToggleButtonClickedCommand != null)
            {
                ToggleButtonClickedCommand.Execute(ToggleButtonClickedCommandParameter);
            }
        }

        /// <summary>
        /// Handles the PointerReleased event of the RightArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Windows.UI.Xaml.Input.PointerRoutedEventArgs"/> instance containing the event data.</param>
        private void RightArea_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (!RightToggle)
            {
                VisualStateManager.GoToState(this, "RighAreaMouseUp", true);
            }
            RightToggle = !RightToggle;
        }

        /// <summary>
        /// Handles the LostFocus event of the SplitButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SplitButton_LostFocus(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "RightAreaHoverOut", true);
            RightToggle = false;
        }
    }
}
