using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAPI.Models.Breedd;
using AnimalAPI.Models.Speciee;
using AnimalAPI.Models.AnimalInformationn;
namespace AnimalAPI.Models.Animall;

public interface IAnimal : IHasAnimalInfo
{
    public int AnimalId { get; set; }
    public int SpecieId { get; set; }
    public int BreedId { get; set; }
    public Specie Specie { get; set; }
    public Breed Breed { get; set; }
    
}
