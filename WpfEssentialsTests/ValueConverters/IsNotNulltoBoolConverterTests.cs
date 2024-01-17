using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEssentials.ValueConverters;

namespace WpfEssentialsTests.ValueConverters
{
    [TestFixture]
    public class IsNotNullToBoolConverterTests
    {
        [Test]
        public void Convert_ReturnsFalse_IfValueIsNull()
        {
            var converterStub = new IsNotNullToBoolConverter();

            var returnValue = converterStub.Convert(null, typeof(object), null, CultureInfo.InvariantCulture);

            Assert.That(returnValue, Is.False);
        }

        [Test]
        public void Convert_ReturnsTrue_IfValueIsNotNull()
        {
            var converterStub = new IsNotNullToBoolConverter();

            var returnValue = converterStub.Convert(1, typeof(object), null, CultureInfo.InvariantCulture);

            Assert.That(returnValue, Is.True);
        }
    }
}
