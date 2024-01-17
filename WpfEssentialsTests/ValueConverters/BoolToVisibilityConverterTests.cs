using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NUnit.Framework;
using WpfEssentials.ValueConverters;

namespace WpfEssentialsTests.ValueConverters
{
    [TestFixture]
    public class BoolToVisibilityConverterTests
    {
        [Test]
        public void Convert_ThrowsArgumentNullException_IfValueIsNull()
        {
            var converterStub = new BoolToVisibilityConverter();

            Assert.Throws(typeof(ArgumentNullException),
                () => converterStub.Convert(null, typeof(object), null, CultureInfo.InvariantCulture));
        }

        [Test]
        public void Convert_ReturnsVisibilityVisible_IfValueIsTrue()
        {
            var converterStub = new BoolToVisibilityConverter();

            var visibility = (Visibility)converterStub.Convert(true, typeof(object), null, CultureInfo.InvariantCulture);

            Assert.That(visibility, Is.EqualTo(Visibility.Visible));
        }

        [Test]
        public void Convert_ReturnsVisibilityCollapsed_IfValueIsFalse()
        {
            var converterStub = new BoolToVisibilityConverter();

            var visibility = (Visibility)converterStub.Convert(false, typeof(object), null, CultureInfo.InvariantCulture);

            Assert.That(visibility, Is.EqualTo(Visibility.Collapsed));
        }

        [Test]
        public void Convert_ReturnsVisibilityHidden_IfValueIsTrueAndParameterIsParameterHidden()
        {
            var converterStub = new BoolToVisibilityConverter();

            var visibility = (Visibility)converterStub.Convert(false, typeof(object), "hidden", CultureInfo.InvariantCulture);

            Assert.That(visibility, Is.EqualTo(Visibility.Hidden));
        }

        [Test]
        public void ConvertBack_ReturnsTrue_IfValueIsVisibilityVisible()
        {
            var converterStub = new BoolToVisibilityConverter();

            var boolReturn = (bool)converterStub.ConvertBack(Visibility.Visible, typeof(object), null,
                CultureInfo.InvariantCulture);

            Assert.That(boolReturn, Is.True);
        }

        [Test]
        public void ConvertBack_ReturnsFalse_IfValueIsVisibilityHidden()
        {
            var converterStub = new BoolToVisibilityConverter();

            var boolReturn = (bool)converterStub.ConvertBack(Visibility.Hidden, typeof(object), null,
                CultureInfo.InvariantCulture);

            Assert.That(boolReturn, Is.False);
        }


        [Test]
        public void ConvertBack_ReturnsFalse_IfValueIsVisibilityCollapsed()
        {
            var converterStub = new BoolToVisibilityConverter();

            var boolReturn = (bool)converterStub.ConvertBack(Visibility.Hidden, typeof(object), null,
                CultureInfo.InvariantCulture);

            Assert.That(boolReturn, Is.False);
        }
    }
}
