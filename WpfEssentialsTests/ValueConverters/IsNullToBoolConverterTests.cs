using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WpfEssentials.ValueConverters;

namespace WpfEssentialsTests.ValueConverters
{
    [TestFixture]
    public class IsNullToBoolConverterTests
    {
        [Test]
        public void Convert_ReturnsTrue_IfValueIsNull()
        {
            var converterStub = new IsNullToBoolConverter();

            var returnValue = converterStub.Convert(null, typeof(object), null, CultureInfo.InvariantCulture);

            Assert.That(returnValue, Is.True);
        }

        [Test]
        public void Convert_ReturnsFalse_IfValueIsNotNull()
        {
            var converterStub = new IsNullToBoolConverter();

            var returnValue = converterStub.Convert(1, typeof(object), null, CultureInfo.InvariantCulture);

            Assert.That(returnValue, Is.False);
        }
    }
}
