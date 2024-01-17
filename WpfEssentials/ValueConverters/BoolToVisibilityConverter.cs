using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfEssentials.ValueConverters
{
    /// <summary>
    /// Implementation of <see cref="IValueConverter"/> that converts a bool value to a visibility value and vice versa.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        private const string ParameterHidden = "hidden";

        /// <summary>
        /// Converts a bool value to a visibility.
        /// </summary>
        /// <param name="value">Bool value to be converted. Must not be null.</param>
        /// <param name="targetType">Not used.</param>
        /// <param name="parameter">Converter parameter string. If it equals the constant <see cref="ParameterHidden"/>,
        /// <see cref="Visibility.Hidden"/> is returned if value is false.</param>
        /// <param name="culture">Not used.</param>
        /// <returns>'Visibility.Visible' if value is true, 'Visibility.Collapsed' if value is false
        /// and parameter equals <see cref="ParameterHidden"/> and 'Visibility.Hidden' otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if value is null.</exception>
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value is not bool boolValue) throw new ArgumentException("Value must be of type bool.", nameof(value));

            if (boolValue) return Visibility.Visible;

            if (parameter is string parameterString
                && parameterString.Equals(ParameterHidden, StringComparison.OrdinalIgnoreCase))
            {
                return Visibility.Hidden;
            }

            return Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a visibility to a bool.
        /// </summary>
        /// <param name="value">Visibility to be converted. Must not be null.</param>
        /// <param name="targetType">Not used.</param>
        /// <param name="parameter">Not used.</param>
        /// <param name="culture">Not used.</param>
        /// <returns>True is value is 'Visibility.Visible' and false otherwise.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if value is neither 'Visibility.Visible',
        /// 'Visibility.Hidden' nor 'Visibility.Collapsed'</exception>
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value is not Visibility visibility) throw new ArgumentException("Value must be of type Visibility.", nameof(value));

            return visibility switch
            {
                Visibility.Visible => true,
                Visibility.Hidden => false,
                Visibility.Collapsed => false,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value,
                    "Value must either be 'Visibility.Visible', 'Visibility.Hidden' or 'Visibility.Collapsed'")
            };
        }
    }
}
