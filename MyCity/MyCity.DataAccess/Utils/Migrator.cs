using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MyCity.Core.Abstractions;
using MyCity.Core.Domain;

namespace MyCity.DataAccess.Utils
{
    internal class Migrator : IMigrator
    {
        private readonly ApplicationDbContext _context;

        public Migrator(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Migrate()
        {
            var firstRun = !_context.Database.GetService<IRelationalDatabaseCreator>().HasTables();

            _context.Database.Migrate();   

            if (firstRun)
            {
                SeedData();
            }

        }

        private void SeedData()
        {
            var roles = new List<Role>
            {
                new Role
                {
                    Name = "Администратор"
                },
                new Role
                {
                    Name = "Модератор"
                },
                new Role
                {
                    Name = "Пользователь"
                }
            };
            _context.AddRange(roles);
            _context.SaveChanges();
        }
    }
}
