﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace AppBarCustomization {
    class Bool2VisibilityConverter:IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if(value is bool) {
                if((bool)value) {
                    return Visibility.Visible;
                }

                else {
                    return Visibility.Collapsed;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
