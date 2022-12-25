using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAPI.Models.Animall;
using AnimalAPI.Models.Breedd;
using AnimalAPI.Models.Speciee;
using Microsoft.EntityFrameworkCore;
namespace AnimalAPI.Data;

public class AnimalAPIDbContext : DbContext
{
    public AnimalAPIDbContext(DbContextOptions<AnimalAPIDbContext> options) : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; }
    public DbSet<Specie> Species { get; set; }
    public DbSet<Breed> Breeds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
        // temporary configuration
        
        modelBuilder.Entity<Animal>()
                    .HasKey(ani => ani.AnimalId);

        modelBuilder.Entity<Specie>()
                    .HasKey(spec => spec.SpecieId);
                    
        modelBuilder.Entity<Breed>()
                    .HasKey(brd => brd.BreedId);
        //

        // dummy data
        
        modelBuilder.Entity<Animal>().HasData(
            new Animal { AnimalId = 6, BreedId = 6, SpecieId = 6}
        );

        modelBuilder.Entity<Specie>().HasData(
            new Specie { SpecieId = 6, SName = "Horse" }
        );

        modelBuilder.Entity<Breed>().HasData(

            new Breed { BreedId = 6, BName = "Mangalarga Marchador"}
        );
        
        //
    
    }
}
