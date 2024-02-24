using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using WpfWindowHandling.ViewModels;

namespace WpfWindowHandling.Services
{
    /// <summary>
    /// Service for handling window operations.
    /// </summary>
    public interface IWindowService
    {
        /// <summary>
        /// Opens a new window.
        /// </summary>
        /// <typeparam name="T">Type of window to open.</typeparam>
        void OpenNewWindow<T>() where T : Window;

        /// <summary>
        /// Minimizes the window.
        /// </summary>
        /// <param name="window">Window to minimize.</param>
        void Minimize(Window window);

        /// <summary>
        /// Maximizes the window.
        /// </summary>
        /// <param name="window">Window to maximize.</param>
        void Maximize(Window window);

        /// <summary>
        /// Restores the window.
        /// </summary>
        /// <param name="window">Window to restore.</param>
        void Restore(Window window);

        /// <summary>
        /// Subscribes to the view model's window operation events, i.e. close, minimize, maximize, and restore.
        /// </summary>
        /// <param name="window">Window to subscribe to the events.</param>
        /// <param name="viewModel">View model that exposes the events to subscribe to.</param>
        void SubscribeToWindowEvents(Window window);

        /// <summary>
        /// Switches the window theme from dark to light and vice versa.
        /// </summary>
        /// <param name="window">Window whose theme to switch.</param>
        /// <param name="viewModel">Window's view model.</param>
        void SwitchWindowTheme(Window window);
    }
}
