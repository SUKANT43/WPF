using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FlipCard.Controls
{
    public class StarHighlightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return Brushes.Gray;

            int starNumber = (int)values[0];
            int rating = (int)values[1];

            return starNumber <= rating ? Brushes.Gold : Brushes.Gray;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}