using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using TrafficLightSimulator.Helpers;
using TrafficLightSimulator.Model;

namespace TrafficLightSimulator.Converters {
    public class ModeAutomaticConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (value != null) {
                if ((string) value == "Manual") {
                    return Resources.Get<VisualBrush>("HatchBrush");
                } else {
                    return "Transparent";
                }
            }
            
            return "Transparent";
        }
        public object ConvertBack(object value, Type targetType, object parameter,  System.Globalization.CultureInfo culture) { 
            throw new NotImplementedException(); 
        }
    }
}