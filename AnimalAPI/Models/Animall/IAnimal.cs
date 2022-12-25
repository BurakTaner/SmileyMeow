using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Animall;

public interface IAnimal
{
    public int AnimalId { get; set; }
    public int SpecieId { get; set; }
    public int BreedId { get; set; }
}
