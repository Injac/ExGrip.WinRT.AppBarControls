ExGrip.WinRT.AppBarControls
===========================

Split button for Windows 8.1 to be used with AppBars (Top) appbar similar to the Microsoft Weather app

![splitbuttonsample](https://cloud.githubusercontent.com/assets/1821384/4431832/f888855c-467a-11e4-942d-d096baa3cfec.png)


Properties that directly influence the visual apperance of the control
======================================================================



![mainproperties](https://cloud.githubusercontent.com/assets/1821384/4431914/1dd0f59e-467e-11e4-93d0-373633bd19ee.png)


Properties that influence the behaviour of the control
======================================================================

*ToggleOnParentFocusChange (bool)*

When selected updates the  "RightToggle" property after the parent (for example the AppBar) looses focus. You can bind the Visibility property using a converter of any FrameworkElement to hide/show it after the parent element looses focus. In the sample the third SplitButton is using this property (set to true) to show a StackPanel when the toggle-button is pressed. When the app-bar looses focus, the StackPanel disappears as well, and the toggle-button is reset to its initial state (arrow-down).

The second button has set the ToggleOnParentChange propery de-selected (false). Therefore the Button that appears when you hit it's toggle-button will stay there (even when the app-bar is not visible) and the toggle-button will be shown in it's last position (arrow-up, or arrow-down). This allows you to keep the elements to be shown in a visible state.


![toggleonfocuschange](https://cloud.githubusercontent.com/assets/1821384/4432000/524efcfa-4681-11e4-8a97-1bd467862004.png)



