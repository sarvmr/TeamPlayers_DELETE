using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamPlayer.Models;

namespace TeamPlayer.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }


    public DbSet<Team>? Teams { get; set; }
    public DbSet<Player>? Players { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //it means that the TeamName is required
        builder.Entity<Player>().Property(m => m.TeamName).IsRequired();

        
        builder.Entity<Team>().Property(p => p.TeamName).HasMaxLength(30);

        //it specifies the name of the table could be different from the name of the class
        builder.Entity<Team>().ToTable("Team");
        builder.Entity<Player>().ToTable("Player");

        builder.Seed();
    }

}
