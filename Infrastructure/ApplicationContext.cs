using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<EffectModel> Effects { get; set; }
        public DbSet<FileEffects> FileEffects { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EffectModel>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<EffectModel>()
                .Property(e => e.Name)
                .IsRequired();

            modelBuilder.Entity<FileEffects>(e =>
            {
                e.HasOne(x => x.Effect)
                .WithMany(x => x.FileEffects)
                .HasForeignKey(x => x.EffectId);

                e.HasOne(x => x.File)
                .WithMany(x => x.FileEffects)
                .HasForeignKey(x => x.FileId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
