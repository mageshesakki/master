using GlobussoftTechnologies.ChatlistUIModule.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace GlobussoftTechnologies.ChatlistUIModule.Converters
{
    public class TextAlignmentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (values != null)
            {
                long senderid = (long)values[0];
                var details = ((ObservableCollection<Chat>)values[2]);
                
                if (details!=null && ((Chat)details[0]).SenderId == senderid)
                    return HorizontalAlignment.Left;
                else 
                    return HorizontalAlignment.Right;
            }
            return HorizontalAlignment.Left;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
