 using System;
using Microsoft.EntityFrameworkCore;

namespace TodolistNg.Data
{
	public class DataContext : DbContext
	{

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DataContext(DbContextOptions<DataContext> options)
		{
		}

		public DbSet<Task> Tasks { get; set; }
		public DbSet<TaskType> TaskTypes { get; set; }
		public DbSet<Status> Statuses { get; set; }
	}
}

