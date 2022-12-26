using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.AnimalInformationn;

public interface IHasAnimalInfo
{
    int AnimalInfoId { get; set; }
    AnimalInfo AnimalInfo { get; set; }
}
