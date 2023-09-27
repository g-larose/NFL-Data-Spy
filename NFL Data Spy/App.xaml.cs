using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NFL_Data_Spy.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace NFL_Data_Spy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;
        //static IConfiguration? configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        public App()
        {
            _host = new HostBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<AppViewModel>();
                    services.AddSingleton<MainWindow>(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<AppViewModel>()
                    });
                    services.AddDbContextFactory<AppDbContext>();
                    services.AddSingleton<IDataService, DataService>();
                    services.AddSingleton<IMessenger, WeakReferenceMessenger>(provider =>
                         provider.GetRequiredService<WeakReferenceMessenger>());
                    services.AddSingleton<IHtmlDocument, HtmlDocumentService>();

                    
                }).Build();
           
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _host.StopAsync();
            _host.Dispose();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _host.StartAsync();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
    }
}