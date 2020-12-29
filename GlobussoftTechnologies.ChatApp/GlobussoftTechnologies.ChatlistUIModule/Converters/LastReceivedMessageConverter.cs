using System;
using System.Windows.Data;

namespace GlobussoftTechnologies.ChatlistUIModule.Converters
{
    public class LastReceivedMessageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (values != null)
            {
                long id = (long)values[0];
                long selectedId = (long)values[1];
                Services.IDataService dataservice = (Services.IDataService)values[2];
                string message = dataservice.GetLastMessage(id, selectedId);
                return message;
            }
            return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
