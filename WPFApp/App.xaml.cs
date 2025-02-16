using EF_Test;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EF_Test_WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize the DbContext
            using (var db = new AppDbContext())
            {
                // Ensure the database is created and migrations are applied
                db.Database.Migrate();
            }
        }
    }
}