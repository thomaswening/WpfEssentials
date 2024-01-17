using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WpfEssentials.Base;

namespace WpfEssentialsTests.Base
{
    [TestFixture]
    public class ObservableObjectTests
    {
        private class ObservableObjectStub : ObservableObject
        {
            private int _propertyStub;

            public int PropertyStub
            {
                get => _propertyStub;
                set => SetField(ref _propertyStub, value);
            }

            public void ExecuteOnPropertyChanged([CallerMemberName] string? propertyName = null) => OnPropertyChanged(propertyName);

            public bool ExecuteSetField(int value) => SetField(ref _propertyStub, value);
        }

        [Test]
        public void OnPropertyChanged_InvokesPropertyChangedEventWithPropertyName_Always()
        {
            var wasInvoked = false;
            var eventArgsPropertyName = string.Empty;

            var observableObjectMock = new ObservableObjectStub();
            observableObjectMock.PropertyChanged += (s, e) =>
            {
                wasInvoked = true;
                eventArgsPropertyName = e.PropertyName;
            };

            observableObjectMock.ExecuteOnPropertyChanged(nameof(ObservableObjectStub.PropertyStub));

            Assert.That(wasInvoked, Is.True);
            Assert.That(eventArgsPropertyName, Is.EqualTo(nameof(ObservableObjectStub.PropertyStub)));
        }


        [Test]
        public void SetField_SetsFieldToNewValueAndInvokesPropertyChangedAndReturnsTrue_IfNewValueIsNotEqual()
        {
            var wasInvoked = false;
            bool? returnValue;
            var observableObjectMock = new ObservableObjectStub();
            observableObjectMock.PropertyChanged += (s, e) => { wasInvoked = true; };

            returnValue = observableObjectMock.ExecuteSetField(1);

            Assert.That(observableObjectMock.PropertyStub, Is.EqualTo(1));
            Assert.That(wasInvoked, Is.True);
            Assert.That(returnValue, Is.True);
        }

        [Test]
        public void SetField_DoesNotSetFieldToNewValueAndDoesNotInvokePropertyChangedAndReturnsFalse_IfNewValueIsEqual()
        {
            var wasInvoked = false;
            bool? returnValue;
            var observableObjectMock = new ObservableObjectStub();
            observableObjectMock.PropertyChanged += (s, e) => { wasInvoked = true; };

            returnValue = observableObjectMock.ExecuteSetField(0);

            Assert.That(observableObjectMock.PropertyStub, Is.EqualTo(0));
            Assert.That(wasInvoked, Is.False);
            Assert.That(returnValue, Is.False);
        }
    }
}
