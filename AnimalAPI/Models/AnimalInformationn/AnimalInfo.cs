using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.AnimalInformationn;

public class AnimalInfo : IAnimalInfo
{
    public int AnimalInfoId { get; set; }
    public string AnimalInformation { get; set; }
}
