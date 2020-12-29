using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace GlobussoftTechnologies.ChatlistUIModule.Converters
{
    public class UniversalDateToTimeConverter : IValueConverter
    {
        public object Convert(object values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values != null)
            {
                return  ((DateTime)values).ToString("h:mm tt");
            }
            return values;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
