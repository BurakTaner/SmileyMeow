using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAPI.Models.AnimalInformationn;
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
    public DbSet<AnimalInfo> AnimalInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
        // temporary configuration
        
        modelBuilder.Entity<Animal>()
                    .HasKey(ani => ani.AnimalId);

        modelBuilder.Entity<Specie>()
                    .HasKey(spec => spec.SpecieId);
                    
        modelBuilder.Entity<Breed>()
                    .HasKey(brd => brd.BreedId);
        
        modelBuilder.Entity<AnimalInfo>()
                    .HasKey(ai => ai.AnimalInfoId);
        //

        // dummy data
        
        modelBuilder.Entity<Animal>().HasData(
            new Animal { AnimalId = 6, BreedId = 6, SpecieId = 6, AnimalInfoId = 6},
            new Animal { AnimalId = 7, BreedId = 7, SpecieId = 7, AnimalInfoId = 7},
            new Animal { AnimalId = 9, BreedId = 8, SpecieId = 8, AnimalInfoId = 9},
            new Animal { AnimalId = 8, BreedId = 9, SpecieId = 9, AnimalInfoId = 8}
        );

        modelBuilder.Entity<Specie>().HasData(
            new Specie { SpecieId = 6, SName = "Horse" },
            new Specie { SpecieId = 7, SName = "Cat" },
            new Specie { SpecieId = 8, SName = "Rabbit" },
            new Specie { SpecieId = 9, SName = "Salamander" }
        );

        modelBuilder.Entity<Breed>().HasData(
            new Breed { BreedId = 6, BName = "Shire Horse"},
            new Breed { BreedId = 7, BName = "Maine Coon"},
            new Breed { BreedId = 8, BName = "American Rabbit"},
            new Breed { BreedId = 9, BName = "Axolot"}
        );
        
        modelBuilder.Entity<AnimalInfo>().HasData(
            new AnimalInfo { AnimalInfoId = 6, AnimalInformation = "The Shire is a British breed of draught horse. It is usually black, bay, or grey. It is a tall breed, and Shires have at various times held world records both for the largest horse and for the tallest horse. The Shire has a great capacity for weight-pulling; it was used for farm work, to tow barges at a time when the canal system was the principal means of goods transport, and as a cart-horse for road transport. One traditional use was for pulling brewer's drays for delivery of beer, and some are still used in this way; others are used for forestry, for riding and for commercial promotion." },
            new AnimalInfo { AnimalInfoId = 7, AnimalInformation = "The Maine Coon is a large domesticated cat breed. It is one of the oldest natural breeds in North America. The breed originated in the U.S. state of Maine, where it is the official state cat.The breed was popular in cat shows in the late 19th century, but its existence became threatened when long-haired breeds from overseas were introduced in the early 20th century. The Maine Coon has since made a comeback and is now the third most popular pedigreed cat breed in the world." },
            new AnimalInfo { AnimalInfoId = 8 ,AnimalInformation = "The axolotl (/æksəlɒtəl/; from Classical Nahuatl: āxōlōtl, Ambystoma mexicanum, is a paedomorphic salamander closely related to the tiger salamander.Axolotls are unusual among amphibians in that they reach adulthood without undergoing metamorphosis. Instead of taking to the land, adults remain aquatic and gilled. The species was originally found in several lakes underlying what is now Mexico City, such as Lake Xochimilco and Lake Chalco.[1] These lakes were drained by Spanish settlers after the conquest of the Aztec Empire, leading to the destruction of much of the axolotl’s natural habitat."},
            new AnimalInfo { AnimalInfoId = 9, AnimalInformation = "The American Rabbit is a breed of rabbit, recognized by the American Rabbit Breeders Association (ARBA) in 1917. By the ARBA standard, American rabbits have a mandolin body shape. It has also been noted for a good 'sweet' temperament and good mothering abilities. As with all domestic rabbits, the American breed is of the species Oryctolagus cuniculus, the European wild rabbit. The American Rabbit was originally accepted into the ARBA as a 'Blue' rabbit, and historically has been characterized as having the deepest, darkest fur of all blue or grey rabbits. The color at its best is 'uniform rich, dark slate-blue, free from white hairs, sandy or rust color"}
        );

        //
    
    }
}
