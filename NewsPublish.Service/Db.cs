using Microsoft.EntityFrameworkCore;
using NewsPublish.Model.Entity;
using System;


namespace NewsPublish.Service
{
    public class Db : DbContext
    {
        public Db()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-QIK3O8F;Initial Catalog=NewsPublish;User ID=sa;Password=@cppei123"
                ,b=>b.UseRowNumberForPaging());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsClassify> NewsClassify { get; set; }
        public virtual DbSet<NewsComment> NewsComment { get; set; }
    }
}
