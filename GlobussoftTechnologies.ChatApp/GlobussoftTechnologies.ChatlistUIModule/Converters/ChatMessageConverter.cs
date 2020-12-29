using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace GlobussoftTechnologies.ChatlistUIModule.Converters
{
    public class ChatMessageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string message = string.Empty;
            if (values != null)
            {
                long senderid = (long)values[0];
                long receiverid = (long)values[1];
                message = (string)values[2];
                if (!string.IsNullOrEmpty(message) && message.Contains(senderid.ToString()))
                    return message.Replace(senderid.ToString(), String.Empty);
                else if (!string.IsNullOrEmpty(message) && message.Contains(receiverid.ToString()))
                    return message.Replace(receiverid.ToString(), String.Empty);
            }
            return message;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
