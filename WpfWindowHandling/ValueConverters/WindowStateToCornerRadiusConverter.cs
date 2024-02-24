using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfWindowHandling.ValueConverters;

/// <summary>
/// Converts a <see cref="WindowState"/> to a <see cref="CornerRadius"/>.
/// </summary>
public class WindowStateToCornerRadiusConverter : IValueConverter
{
    /// <summary>
    /// Converts a <see cref="WindowState"/> to a <see cref="CornerRadius"/>.
    /// </summary>
    /// <param name="value">Window state to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Radius of the CornerRadius to return. Default is 10. Must be a positive double.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>CornerRadius object of radius 0 if WindowState is Maximized.
    /// Otherwise, CornerRadius object of radius passed in the parameter or a default radius of 10 if parameter is null.</returns>
    /// <exception cref="ArgumentException">Throw if value is not a WindowState or parameter is not a string.</exception>
    /// <exception cref="InvalidOperationException">Thrown if parameter cannot be parsed to a double or is not a positive double.</exception>
    public object Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (value is not WindowState state)
            throw new ArgumentException("The value must be of type WindowState.", nameof(value));

        double radius = -1;
        if (parameter is not null)
        {
            if (parameter is not string) 
                throw new ArgumentException("The parameter must be a string.", nameof(parameter));

            if (!double.TryParse(parameter.ToString(), out radius))
                throw new InvalidOperationException($"Could not parse parameter to double. Parameter: {parameter}");

            if (radius < 0)
                throw new InvalidOperationException($"Corner radius must be positive. Parameter: {parameter}");
        }

        if (radius < 0) radius = 10;

        return state == WindowState.Maximized ? new CornerRadius(0) : new CornerRadius(radius);
    }

    /// <summary>
    /// Not implemented.
    /// </summary>
    public object ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
