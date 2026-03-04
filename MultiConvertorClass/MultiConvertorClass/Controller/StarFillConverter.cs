using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MultiConvertorClass.Controller
{
    public class StarFillConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null || values[1] == null)
            {
                return Brushes.Gray;
            }
            
            int startnumber = System.Convert.ToInt32(values[0]);
            int rating = System.Convert.ToInt32(values[1]);

            return startnumber <= rating ? Brushes.Gold : Brushes.Gray;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
