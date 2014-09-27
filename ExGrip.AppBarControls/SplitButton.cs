using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using System.Windows.Input;
using System.Windows;

namespace ExGrip.AppBarControls {

    // event delegate handler
    public delegate void LeftAreaClicked(object s, EventArgs e);
    public delegate void ToggleAreaClicked(object s, EventArgs e);


    [TemplatePart(Name = "PART_ToggleThumb", Type = typeof(Border))]
    [TemplatePart(Name = "PART_LeftArea", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_RightArea", Type = typeof(Grid))]
    public class SplitButton : Control {



        private Border thumb;
        private Grid leftArea;
        private Grid rightArea;


        #region Events
        private event LeftAreaClicked leftAreaButtonClicked;

        public event LeftAreaClicked LeftAreaButtonClicked {
            add {
                leftAreaButtonClicked += value;
            }

            remove {
                leftAreaButtonClicked -= value;
            }
        }

        private event ToggleAreaClicked toggleAreaButtonClicked;


        public event ToggleAreaClicked ToggleAreaButtonClicked {
            add {
                toggleAreaButtonClicked += value;
            }

            remove {
                toggleAreaButtonClicked -= value;
            }
        }
        #endregion

        #region DependencyProperties

        public bool RightToggle {
            get {
                return (bool)GetValue(RightToggleProperty);
            }

            set {
                SetValue(RightToggleProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for RightToggle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightToggleProperty =
            DependencyProperty.Register("RightToggle", typeof(bool), typeof(SplitButton), new PropertyMetadata(null));



        public bool ToggleOnParentFocusChange {
            get {
                return (bool)GetValue(ToggleOnParentFocusChangeProperty);
            }

            set {
                SetValue(ToggleOnParentFocusChangeProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ToggleOnParentFocusChange.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToggleOnParentFocusChangeProperty =
            DependencyProperty.Register("ToggleOnParentFocusChange", typeof(bool), typeof(SplitButton), new PropertyMetadata(false));




        public Visibility ToggleAreaVisibility {
            get {
                return (Visibility)GetValue(ToggleAreaVisibilityProperty);
            }

            set {
                SetValue(ToggleAreaVisibilityProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ToggleAreaVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToggleAreaVisibilityProperty =
            DependencyProperty.Register("ToggleAreaVisibility",
                                        typeof(Visibility), typeof(SplitButton),
                                        new PropertyMetadata(null, new PropertyChangedCallback(RightAreaVisibilityChanged))
                                       );




        public object LeftAreaMouseDownCommandParameter {
            get {
                return (object)GetValue(LeftAreaMouseDownCommandParameterProperty);
            }

            set {
                SetValue(LeftAreaMouseDownCommandParameterProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for RightAreaMouseDownCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftAreaMouseDownCommandParameterProperty =
            DependencyProperty.Register("LeftAreaMouseDownCommandParameter", typeof(object), typeof(SplitButton), new PropertyMetadata(null));



        public ICommand LeftAreaMouseDownCommand {
            get {
                return (ICommand)GetValue(LeftAreaMouseDownCommandProperty);
            }

            set {
                SetValue(LeftAreaMouseDownCommandProperty, value);
            }
        }





        // Using a DependencyProperty as the backing store for RightAreaMouseDownCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftAreaMouseDownCommandProperty =
            DependencyProperty.Register("LeftAreaMouseDownCommand", typeof(ICommand), typeof(SplitButton), new PropertyMetadata(null));





        public object ToggleButtonClickedCommandParameter {
            get {
                return (object)GetValue(ToggleButtonClickedCommandParameterProperty);
            }

            set {
                SetValue(ToggleButtonClickedCommandParameterProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ToggleButtonClickedCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToggleButtonClickedCommandParameterProperty =
            DependencyProperty.Register("ToggleButtonClickedCommandParameter", typeof(object), typeof(SplitButton), new PropertyMetadata(null));




        public ICommand ToggleButtonClickedCommand {
            get {
                return (ICommand)GetValue(ToggleButtonClickedCommandProperty);
            }

            set {
                SetValue(ToggleButtonClickedCommandProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ToggleButtonClickedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToggleButtonClickedCommandProperty =
            DependencyProperty.Register("ToggleButtonClickedCommand", typeof(ICommand), typeof(SplitButton), new PropertyMetadata(null));




        public Brush ThumbFill {
            get {
                return (Brush)GetValue(ThumbFillProperty);
            }

            set {
                SetValue(ThumbFillProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ThumbFill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ThumbFillProperty =
            DependencyProperty.Register("ThumbFill", typeof(Brush), typeof(SplitButton), new PropertyMetadata(null));



        public Brush LeftAreaBackground {
            get {
                return (Brush)GetValue(LeftAreaBackgroundProperty);
            }

            set {
                SetValue(LeftAreaBackgroundProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for LeftAreaBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftAreaBackgroundProperty =
            DependencyProperty.Register("LeftAreaBackground", typeof(Brush), typeof(SplitButton), new PropertyMetadata(null));



        public Brush RightAreaBackground {
            get {
                return (Brush)GetValue(RightAreaBackgroundProperty);
            }

            set {
                SetValue(RightAreaBackgroundProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for RightAreaBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightAreaBackgroundProperty =
            DependencyProperty.Register("RightAreaBackground", typeof(Brush), typeof(SplitButton), new PropertyMetadata(null));



        public string Caption {
            get {
                return (string)GetValue(CaptionProperty);
            }

            set {
                SetValue(CaptionProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(SplitButton), new PropertyMetadata("Caption"));



        public ImageSource TopImage {
            get {
                return (ImageSource)GetValue(TopImageProperty);
            }

            set {
                SetValue(TopImageProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for TopImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TopImageProperty =
            DependencyProperty.Register("TopImage", typeof(ImageSource), typeof(SplitButton), new PropertyMetadata(null));

        #endregion

        public SplitButton() {
            this.DefaultStyleKey = typeof(SplitButton);
            this.MinWidth = 170;
            this.MinHeight = 100;
        }


        private static void RightAreaVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {



            var controlInstance = (SplitButton)d;

            var grid = controlInstance.GetTemplateChild("PART_LeftArea") as Grid;

            if (grid != null) {
                if (((Visibility) e.NewValue) == Visibility.Collapsed) {
                    grid.SetValue(Grid.ColumnSpanProperty, 2);
                    var parentGrid = grid.Parent as Grid;
                    grid.InvalidateMeasure();
                    parentGrid.InvalidateMeasure();
                }

                else {
                    grid.SetValue(Grid.ColumnSpanProperty, 1);
                    var parentGrid = grid.Parent as Grid;
                    grid.InvalidateMeasure();
                    parentGrid.InvalidateMeasure();
                }
            }
        }



        protected override void OnApplyTemplate() {

            this.thumb = this.GetTemplateChild("PART_ToggleThumb") as Border;
            this.leftArea = this.GetTemplateChild("PART_LeftArea") as Grid;
            this.rightArea = this.GetTemplateChild("PART_RightArea") as Grid;


            if (leftArea != null) {
                this.leftArea.PointerPressed += leftArea_PointerPressed;
                this.leftArea.PointerReleased += leftArea_PointerReleased;
                this.leftArea.PointerEntered += leftArea_PointerEntered;
                this.leftArea.PointerExited += leftArea_PointerExited;
            }

            if (rightArea != null) {
                this.rightArea.PointerPressed += rightArea_PointerPressed;
                this.rightArea.PointerReleased += rightArea_PointerReleased;
                this.rightArea.PointerEntered += rightArea_PointerEntered;
                this.rightArea.PointerExited += rightArea_PointerExited;
            }

            this.LostFocus += SplitButton_LostFocus;



            base.OnApplyTemplate();


            if(this.Parent is FrameworkElement) {
                var parent = this.Parent as FrameworkElement;

                if(this.ToggleOnParentFocusChange) {
                    parent.LostFocus+=parent_LostFocus;
                }

                else {
                    parent.LostFocus -= parent_LostFocus;
                }
            }

            this.ToggleAreaVisibility = this.ToggleAreaVisibility;
        }



        void parent_LostFocus(object sender, RoutedEventArgs e) {

            this.RightToggle = false;
            VisualStateManager.GoToState(this, "RightAreaHoverOut", true);

        }

        void SplitButton_LostFocus(object sender, RoutedEventArgs e) {

            VisualStateManager.GoToState(this, "RightAreaHoverOut", true);

            RightToggle = false;
        }



        void rightArea_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) {

            if (!RightToggle) {
                VisualStateManager.GoToState(this, "RightAreaHoverOut", true);

            }

            else {
                VisualStateManager.GoToState(this, "RightToggle", true);
            }
        }

        void rightArea_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) {
            if (!RightToggle) {

                VisualStateManager.GoToState(this, "RightAreaHover", true);
            }

            else {
                VisualStateManager.GoToState(this, "RightHoverToggle", true);

            }
        }

        void rightArea_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) {

            if (!RightToggle) {
                VisualStateManager.GoToState(this, "RighAreaMouseUp", true);
            }

            RightToggle = !RightToggle;

        }

        void rightArea_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) {

            if (RightToggle) {
                VisualStateManager.GoToState(this, "RightAreaMouseDown", true);


            }

            else {
                VisualStateManager.GoToState(this, "RightAreaHoover", true);

            }



            if (this.toggleAreaButtonClicked != null) {
                this.toggleAreaButtonClicked.Invoke(this, new EventArgs());
            }

            if (this.ToggleButtonClickedCommand != null) {
                this.ToggleButtonClickedCommand.Execute(this.ToggleButtonClickedCommandParameter);
            }


        }

        void leftArea_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) {
            VisualStateManager.GoToState(this, "LeftAreaHoverOut", true);
        }

        void leftArea_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) {
            VisualStateManager.GoToState(this, "LeftAreaHover", true);
        }

        void leftArea_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) {
            VisualStateManager.GoToState(this, "LeftAreaMouseUp", true);

            if (this.LeftAreaMouseDownCommand != null) {
                this.LeftAreaMouseDownCommand.Execute(this.LeftAreaMouseDownCommandParameter);
            }
        }

        void leftArea_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) {

            VisualStateManager.GoToState(this, "LeftAreaMouseDown", true);

            if(this.leftAreaButtonClicked!=null) {
                this.leftAreaButtonClicked.Invoke(this, new EventArgs());
            }



        }
    }
}
