using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace 測試模型.Models.DbModel
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DataContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string cuse = configuration["ConnectionUse"].ToString();
                switch (cuse)
                {
                    case "UseSqlServer":
                        optionsBuilder
                            .UseSqlServer(configuration["ConnectionStrings"].ToString());
                        break;
                    case "UseMySQL":
                        break;
                    case "UseMock":
                        break;
                    default:
                        throw new Exception("lose ConnectionUse");
                }
            }
        }

        public virtual DbSet<UserValues> UserValues { get; set; }
    }
}
