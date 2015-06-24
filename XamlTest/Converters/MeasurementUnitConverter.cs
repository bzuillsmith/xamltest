using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace XamlTest.Converters
{
    class MeasurementUnitConverter : IValueConverter
    {
        const string MILLIMETERS_ABBREVIATION = "mm";
        const string INCHES_ABBREVIATION = "in";

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return MILLIMETERS_ABBREVIATION;
            }
            else
            {
                return INCHES_ABBREVIATION;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
