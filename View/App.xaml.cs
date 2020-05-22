using Business.Abstraction;
using Data.Implementation;
using Business.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using View.Model;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            var service = new ServiceCollection();
            ConfigureServices(service);

            ServiceProvider = service.BuildServiceProvider();

            DisplayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        public DisplayRootRegistry DisplayRootRegistry { get; } = new DisplayRootRegistry();

        protected override void OnStartup(StartupEventArgs e)
        {
            
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            serviceCollection.BuildServiceProvider();

            var viewModel = new MainWindowViewModel(ServiceProvider.GetService<IDishService>(), ServiceProvider.GetService<IIngredientService>());

            DisplayRootRegistry.ShowModalPresentation(viewModel);
            Shutdown();
        }
       
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(MainWindow));
            services.RegisterDataServices();
            services.RegisterBusinessServices();
        }
    }
}
