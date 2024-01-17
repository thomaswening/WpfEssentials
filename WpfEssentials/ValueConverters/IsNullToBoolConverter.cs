using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfEssentials.ValueConverters
{
    /// <summary>
    /// Implementation of <see cref="IValueConverter"/> that returns true if the passed value is null
    /// and false otherwise.
    /// </summary>
    public class IsNullToBoolConverter : IValueConverter
    {
        /// <summary>
        /// Converts a passed value into a bool, depending on whether it is null.
        /// </summary>
        /// <param name="value">Value to be checked for null.</param>
        /// <param name="targetType">Not used.</param>
        /// <param name="parameter">Not used.</param>
        /// <param name="culture">Not used.</param>
        /// <returns>True if the passed value is null, false otherwise.</returns>
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is null;
        }

        /// <summary>
        /// Is not implemented.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
