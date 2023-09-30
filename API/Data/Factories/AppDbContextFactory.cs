using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Factories
{
    public class AppDbContextFactory : IDbContextFactory<AppDbContext>, IDisposable
    {
        private DataService _dataService = new DataService();

        public AppDbContext CreateDbContext()
        {
            var conStr = _dataService.GetConnectionString();
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseNpgsql(conStr);

            return new AppDbContext(options.Options);
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
