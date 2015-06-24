using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace XamlTest.Converters
{
    class MeasurementConverter : IValueConverter
    {
        const double MILLIMETERS_IN_ONE_INCH = 25.4;
        const string INCHES_ABBREVIATION = "in";
        const string MILLIMETERS_ABBREVIATION = "mm";

        const double ONE_THIRTY_SECOND = 0.03125;
        const double ONE_SIXTEENTH = 0.0625;
        const double ONE_EIGHTH = 0.125;
        const double ONE_FOURTH = 0.25;
        const double ONE_HALF = 0.5;

        const double ONE = 1;
        public double RoundToNearest(double value, int unitPrecision)
        {
            double fraction = 0;
            int reciprocal = 0;

            switch (unitPrecision)
            {
                case 0:
                    fraction = ONE;
                    reciprocal = (int)ONE;
                    break;
                case 1:
                    fraction = ONE;
                    reciprocal = (int)ONE;
                    break;
                case 2:
                    fraction = ONE_HALF;
                    reciprocal = (int)(1 / ONE_HALF);
                    break;
                case 3:
                    fraction = ONE_FOURTH;
                    reciprocal = (int)(1 / ONE_FOURTH);
                    break;
                case 4:
                    fraction = ONE_EIGHTH;
                    reciprocal = (int)(1 / ONE_EIGHTH);
                    break;
                case 5:
                    fraction = ONE_SIXTEENTH;
                    reciprocal = (int)(1 / ONE_SIXTEENTH);
                    break;
                case 6:
                    fraction = ONE_THIRTY_SECOND;
                    reciprocal = (int)(1 / ONE_THIRTY_SECOND);
                    break;
            }

            return Math.Round(value * reciprocal, MidpointRounding.AwayFromZero) * fraction;

        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strValue = (string)value;
            bool isMetric = (bool)parameter;

            double enteredValue = 0;
            bool enteredValueIsImperial = false;

            if (strValue.EndsWith(INCHES_ABBREVIATION))
            {
                enteredValueIsImperial = true;
                strValue = strValue.Substring(0, strValue.Length - INCHES_ABBREVIATION.Length);
            }
            else if (strValue.EndsWith(MILLIMETERS_ABBREVIATION))
            {
                enteredValueIsImperial = false;
                strValue = strValue.Substring(0, strValue.Length - MILLIMETERS_ABBREVIATION.Length);
            }
            else if (isMetric)
            {
                enteredValueIsImperial = false;
            }
            else
            {
                enteredValueIsImperial = true;
            }

            try
            {
                enteredValue = double.Parse(strValue);
            }
            catch (FormatException)
            {
                return DependencyProperty.UnsetValue;
            }

            if (isMetric)
            {
                if (enteredValueIsImperial)
                {
                    //inches to mm
                    return RoundToNearest(enteredValue * MILLIMETERS_IN_ONE_INCH, 0);
                    //0 is mm
                }
                else
                {
                    //mm to mm
                    return RoundToNearest(enteredValue, 0);
                    //0 is mm
                }
            }
            else
            {
                if (enteredValueIsImperial)
                {
                    //inches to inches
                    return RoundToNearest(enteredValue, 5);
                }
                else
                {
                    //mm to inches
                    return RoundToNearest(enteredValue / MILLIMETERS_IN_ONE_INCH, 5);
                }
            }
        }
    }
}
