using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zarani.Infrastructure.Context;

namespace Zarani.Application.Extentions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using ZaraniDbContext context =scope.ServiceProvider.GetRequiredService<ZaraniDbContext>();
            context.Database.Migrate();
        }
    }
}
