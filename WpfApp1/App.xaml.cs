using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using openc_vraspberry_test.server;
using opencv_raspberry_test.server.Services;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host.CreateDefaultBuilder(e.Args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("https://localhost:5001");
                    webBuilder.UseStartup<Startup>();
                }).Build();

            var speedService = host.Services.GetService<SpeedService>();
            var window = new MainWindow(speedService);
            window.Show();

            await Task.Run(async () =>
            {
                await host.StartAsync();
            });
        }
    }
}
