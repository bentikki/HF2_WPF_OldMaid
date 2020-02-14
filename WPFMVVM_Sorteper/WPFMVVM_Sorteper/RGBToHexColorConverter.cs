using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace RGB
{
    class RGBToHexColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush) {
                SolidColorBrush sc = (SolidColorBrush)value;

                //     return String.Format("#{0:X2}{1:X2}{2:X2}", (byte)sc.Color.R, (byte)sc.Color.G, (byte)sc.Color.B);
                return "RGB(" + (byte)sc.Color.R + ","+ (byte)sc.Color.G + ","+ (byte)sc.Color.B + "))";

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
