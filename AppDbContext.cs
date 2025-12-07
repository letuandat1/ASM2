
using Minecraft.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Minecraft.AppDataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>Options) : base(Options){}
        public DbSet<Player> Players{get;set;}
        public DbSet<PlayerItem> PlayerItems {get;set;}
        public DbSet <Item> Items {get;set;}
        public DbSet <PlayMode> PlayModes {get;set;}
        public DbSet <GameMode> GameModes {get;set;}
        public DbSet <Resource> Resources {get;set;}
        public DbSet <PlayerResource> PlayerResources {get;set;}
        public DbSet <Transaction> Transactions {get;set;}
        public DbSet<Vehicle> Vehicles {get;set;}

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayMode>().HasKey(pm => new { pm. PlayerId, pm.GameModeId});
            modelBuilder.Entity<PlayMode>().HasOne(pm => pm.Player).WithMany(p => p.PlayModes).HasForeignKey (pm => pm.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PlayMode>().HasOne(pm => pm.GameMode)
            .WithMany (g => g.PlayModes)
            .HasForeignKey(pm => pm.GameModeId)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PlayerResource>()
            .HasKey(pr=> new { pr.PlayerId , pr.ResourceId});
            //2
            modelBuilder.Entity<PlayerResource>()
            .HasOne(pr => pr.Player)
            .WithMany(p => p.PlayerResources)
            .HasForeignKey (pr => pr.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PlayerResource>()
            .HasOne(pr => pr.Resource)
            .WithMany(r => r.PlayerResources)
            .HasForeignKey (pr => pr.ResourceId)
            .OnDelete (DeleteBehavior.Cascade);
            //3
            modelBuilder.Entity<PlayerItem>()
            .HasKey(pi => new {pi.PlayerId , pi.ItemId });
            modelBuilder.Entity<PlayerItem>()
            .HasOne(pi => pi.Player)
            .WithMany(p => p.PlayerItems)
            .HasForeignKey (pi => pi.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PlayerItem>()
            .HasOne(pi => pi.Item)
            .WithMany (i => i.PlayerItems)
            .HasForeignKey (pi => pi.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
            //4
            modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Player)
            .WithMany(p => p.Transactions)
            .HasForeignKey (t => t.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Item)
            .WithMany(i => i.Transactions)
            .HasForeignKey(t => t.ItemId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Vehicle)
            .WithMany(v => v.Transactions)
            .HasForeignKey (t => t.VehicleId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Vehicle>()
            .HasKey (v => v.Id);
            modelBuilder.Entity<Player>().HasKey(p => p.Id);
            modelBuilder.Entity<Item>().HasKey(i => i.Id);
            modelBuilder.Entity<GameMode>().HasKey(g => g.Id);
            modelBuilder.Entity<Resource>().HasKey(r => r.Id);
        }
    }
}