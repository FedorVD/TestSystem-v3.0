﻿using Microsoft.EntityFrameworkCore;

namespace TestSystem_v3._0
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Theme> Themes => Set<Theme>();
        public DbSet<User> Users => Set<User>();
        public DbSet<ScoreTable> ScoreTables => Set<ScoreTable>();

        public DbSet<Help> Helps => Set<Help>();
        public ApplicationContext() 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource = TestSystem.db");
        }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScoreTable>().HasNoKey();
        }*/
    }
}
