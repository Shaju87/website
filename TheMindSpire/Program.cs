using Microsoft.EntityFrameworkCore;
using TheMindSpire.Data;

namespace TheMindSpire
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // Use SQLite for cloud deployment, SQL Server for local
            var connectionString = builder.Configuration.GetConnectionString("MindSpireDbConnectionString");
            if (connectionString != null && connectionString.Contains("Data Source=") && connectionString.EndsWith(".db"))
            {
                // SQLite for cloud deployment
                builder.Services.AddDbContext<MindSpireDbContext>(options =>
                    options.UseSqlite(connectionString));
            }
            else
            {
                // SQL Server for local development
                builder.Services.AddDbContext<MindSpireDbContext>(options =>
                    options.UseSqlServer(connectionString));
            }

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
