using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using eShopSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace E_Shop.Data.EF
{
   public class EShopSolutionDbContextFactory: IDesignTimeDbContextFactory<EShopDbContext>
    {
        public EShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("EShopSolutionDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<EShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new EShopDbContext(optionsBuilder.Options);
        }
    }
}
