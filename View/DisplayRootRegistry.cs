using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace View
{
    public class DisplayRootRegistry
    {
        private readonly Dictionary<object, Window> _openWindows = new Dictionary<object, Window>();
        private readonly Dictionary<Type, Type> _vmToWindowMapping = new Dictionary<Type, Type>();

        public void RegisterWindowType<VM, Win>() where Win : Window, new() where VM : class
        {
            var vmType = typeof(VM);
            if (vmType.IsInterface)
                throw new ArgumentException("Cannot register interfaces");
            if (_vmToWindowMapping.ContainsKey(vmType))
                throw new InvalidOperationException(
                    $"Type {vmType.FullName} is already registered");
            _vmToWindowMapping[vmType] = typeof(Win);
        }

        public void UnregisterWindowType<VM>()
        {
            var vmType = typeof(VM);
            if (vmType.IsInterface)
                throw new ArgumentException("Cannot unregister interfaces");
            if (!_vmToWindowMapping.ContainsKey(vmType))
                throw new InvalidOperationException(
                    $"Type {vmType.FullName} is not registered");
            _vmToWindowMapping.Remove(vmType);
        }

        public Window CreateWindowInstanceWithVM(object vm)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");
            Type windowType = null;

            var vmType = vm.GetType();
            while (vmType != null && !_vmToWindowMapping.TryGetValue(vmType, out windowType))
                vmType = vmType.BaseType;

            if (windowType == null)
                throw new ArgumentException(
                    $"No registered window type for argument type {vm.GetType().FullName}");

            var window = (Window)Activator.CreateInstance(windowType);
            window.DataContext = vm;
            return window;
        }

        public void ShowPresentation(object vm)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");
            if (_openWindows.ContainsKey(vm))
                throw new InvalidOperationException("UI for this VM is already displayed");
            var window = CreateWindowInstanceWithVM(vm);
            window.Show();
            _openWindows[vm] = window;
        }

        public void HidePresentation(object vm)
        {
            Window window;
            if (!_openWindows.TryGetValue(vm, out window))
                throw new InvalidOperationException("UI for this VM is not displayed");
            window.Close();
            _openWindows.Remove(vm);
        }

        public void ShowModalPresentation(object vm)
        {
            var window = CreateWindowInstanceWithVM(vm);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }
    }
}
