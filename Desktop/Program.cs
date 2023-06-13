
using App.Services;
using Desktop.Service;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Login());

            var host = Host.CreateDefaultBuilder()
              .ConfigureServices((_, services) =>
              {
                  services.AddDbContext<AppDbContext>(options =>
                  {
                      options.UseSqlServer("Server=localhost;Database=WinForms;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
                  });

                  services.AddScoped<IUserRepository, UserRepository>();
                  services.AddScoped<IUnitOfWork, UnitOfWork>();
                  services.AddScoped<UserService>();

                  services.AddTransient<NavigationService>();
                  services.AddTransient<Login>();
                  services.AddTransient<Main>();
                  services.AddTransient<AddUser>();
                  services.AddTransient<EditUser>();
                  services.AddSingleton<LoginContext>();
              })
              .Build();
            
            using (var serviceScope = host.Services.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                var dbContext = serviceProvider.GetRequiredService<AppDbContext>();

                // Apply any pending migrations
                dbContext.Database.Migrate();
            }

            Application.Run(host.Services.GetRequiredService<Login>());
        }
    }
}