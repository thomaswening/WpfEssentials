using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using WpfWindowHandling.ViewModels;

namespace WpfWindowHandling.Services
{
    public class WindowService() : IWindowService
    {

        private const string DarkThemeUri = "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml";
        private const string LightThemeUri = "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml";

        public virtual void Minimize(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }

        public virtual void Maximize(Window window)
        {
            window.WindowState = WindowState.Maximized;
        }

        public virtual void Restore(Window window)
        {
            window.WindowState = WindowState.Normal;
        }

        public virtual void SubscribeToWindowEvents(Window window)
        {
            var viewModel = (WindowVm)window.DataContext;
            viewModel.CloseWindowRequestedEvent += (_, _) => window.Close();
            viewModel.MinimizeWindowRequestedEvent += (_, _) => Minimize(window);
            viewModel.MaximizeWindowRequestedEvent += (_, _) => Maximize(window);
            viewModel.RestoreWindowRequestedEvent += (_, _) => Restore(window);
        }

        public virtual void SwitchWindowTheme(Window window)
        {
            var viewModel = (WindowVm)window.DataContext;
            var resourceDictionary = GetThemeResourceDictionary(viewModel.IsDarkTheme);
            window.Resources.MergedDictionaries.Clear();
            window.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private static ResourceDictionary GetThemeResourceDictionary(bool isDarkTheme)
        {
            var resourceDictionary = new ResourceDictionary();
            string themeResource = isDarkTheme ? DarkThemeUri : LightThemeUri;
            resourceDictionary.Source = new Uri(themeResource, UriKind.Absolute);
            return resourceDictionary;
        }
    }
}
