using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WpfEssentials;
using WpfEssentials.Base;

namespace WpfEssentialsTests.Base
{
    [TestFixture]
    public class DelegateCommandTests
    {
        [Test]
        public void Constructor_ThrowsArgumentNullException_IfActionIsNull()
        {
            Assert.That(() => new DelegateCommand(null), Throws.Exception);
        }

        [Test]
        public void CanExecute_ReturnsTrue_IfPredicateIsNull()
        {
            var delegateCommandStub = new DelegateCommand(_ => { });

            var returnValue = delegateCommandStub.CanExecute(null);

            Assert.That(returnValue, Is.True);
        }

        [Test]
        public void CanExecute_ReturnsPredicateReturnValue_IfPredicateIsNotNull()
        {
            var delegateCommandStub = new DelegateCommand(_ => { }, _ => true);

            var returnValue = delegateCommandStub.CanExecute(null);

            Assert.That(returnValue, Is.True);
        }

        [Test]
        public void Execute_InvokesTheAction_Always()
        {
            var wasExecuted = false;
            var delegateCommandStub = new DelegateCommand(_ => wasExecuted = true);

            delegateCommandStub.Execute(null);

            Assert.That(wasExecuted, Is.True);
        }

        [Test]
        public void CanExecute_InvokesCanExecuteChangedEvent_Always()
        {
            var wasInvoked = false;
            var delegateCommandStub = new DelegateCommand(_ => { });
            delegateCommandStub.CanExecuteChanged += (s, e) => wasInvoked = true;

            delegateCommandStub.OnCanExecuteChanged();

            Assert.That(wasInvoked, Is.True);
        }
    }
}
