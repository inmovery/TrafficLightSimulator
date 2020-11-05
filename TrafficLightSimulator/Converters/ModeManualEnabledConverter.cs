using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TrafficLightSimulator.Model;

namespace TrafficLightSimulator.Converters {
    public class ModeManualEnabledConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (value != null) {
                if ((string) value == "Manual") {
                    return true;
                } else {
                    return false;
                }
            }
            
            return Visibility.Visible;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
