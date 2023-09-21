using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<AppDbContext>(s => s.UseNpgsql(connectionString));
            return services;
        }
    }
}
