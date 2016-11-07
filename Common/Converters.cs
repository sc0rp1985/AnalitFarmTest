using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Common
{
    [ValueConversion(typeof (double), typeof (double))]
    public class VerticalScrollbarWidthToGridColumnWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            return SystemParameters.VerticalScrollBarWidth;

        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Для скрытия столбца/строки Grid, устанавливая его Width/Height в 0, если переменная биндинга = false
    /// </summary>
    [ValueConversion(typeof (bool), typeof (GridLength))]
    public class BoolToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool) value == false) return new GridLength(0);
            if (parameter != null && (parameter is string) && (string) parameter == "Auto")
                return GridLength.Auto;
            return new GridLength(1, GridUnitType.Star);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
