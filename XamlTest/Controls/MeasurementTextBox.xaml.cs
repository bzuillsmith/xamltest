using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamlTest.Controls
{
    /// <summary>
    /// Interaction logic for MeasurementTextBox.xaml
    /// </summary>
    public partial class MeasurementTextBox : UserControl
    {

        public MeasurementTextBox()
        {
            // This call is required by the designer.
            InitializeComponent();
        }

        public bool UseMetric
        {
            get { return Convert.ToBoolean(GetValue(UseMetricProperty)); }
            set { SetValue(UseMetricProperty, value); }
        }


        public static readonly DependencyProperty UseMetricProperty = DependencyProperty.Register("UseMetric", typeof(bool), typeof(MeasurementTextBox), new PropertyMetadata(MeasurementTextBox.UseMetricChanged));
        private static void UseMetricChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public double Measurement
        {
            get { return (double)GetValue(MeasurementProperty); }
            set { SetValue(MeasurementProperty, value); }
        }


        public static readonly DependencyProperty MeasurementProperty = DependencyProperty.Register("Measurement", typeof(double), typeof(MeasurementTextBox), new PropertyMetadata(MeasurementTextBox.MeasurementPropertyChanged));
        private static void MeasurementPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }


}
