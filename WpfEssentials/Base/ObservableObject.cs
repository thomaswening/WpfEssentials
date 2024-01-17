using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfEssentials.Base
{
    /// <summary>
    /// Implementation of <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Invokes the <see cref="PropertyChanged"/> event with the provided
        /// <see cref="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">Name of the property used to invoke the event. If null,
        /// the name of the calling method is used.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the given <see cref="field"/> to the given <see cref="value"/>
        /// and invokes the <see cref="PropertyChanged"/> event
        /// if the values differs from the value stored in the <see cref="field"/>.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="field"/>.</typeparam>
        /// <param name="field">Field whose value is to be set.</param>
        /// <param name="value">Value that is to be stored in the <see cref="field"/>.</param>
        /// <param name="propertyName">Name of the property that the <see cref="field"/> belongs to.</param>
        /// <returns>True if the values differ and the old one was overwritten, false otherwise.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
