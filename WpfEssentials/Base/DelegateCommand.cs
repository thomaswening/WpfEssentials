using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfEssentials.Base
{
    /// <summary>
    /// Implementation of <see cref="ICommand"/>.
    /// </summary>
    /// <param name="execute">Action to be executed.</param>
    /// <param name="canExecute">Predicate to decide if the action can be executed. May be null.</param>
    public class DelegateCommand(Action<object?> execute, Predicate<object?>? canExecute) : ICommand
    {
        private readonly Action<object?> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

        public DelegateCommand(Action<object?> execute) : this(execute, null) { }

        /// <summary>
        /// If the predicate <paramref name="canExecute"/> is not null, it is executed and its return value is returned.
        /// Otherwise, true is returned. The user is responsible for the null checks and correct type casting
        /// of the <see cref="parameter"/>.
        /// </summary>
        /// <param name="parameter">Parameter to be passed to <paramref name="canExecute"/>.</param>
        /// <returns>True if <paramref name="canExecute"/> is null, 
        /// otherwise the return value of <paramref name="canExecute"/> is returned.</returns>
        public bool CanExecute(object? parameter)
        {
            return canExecute is null || canExecute.Invoke(parameter);
        }

        /// <summary>
        /// Executes the action <see cref="execute"/>.
        /// The user is responsible for the null checks and correct type casting of the <see cref="parameter"/>.
        /// </summary>
        /// <param name="parameter">Parameter to be passed to <see cref="execute"/>.</param>
        public void Execute(object? parameter) => _execute.Invoke(parameter);

        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Invokes the <see cref="CanExecuteChanged"/> event.
        /// </summary>
        public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
