using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.AnimalInformationn;

public interface IAnimalInfo
{
    int AnimalInfoId { get; set; }
    string AnimalInformation { get; set; }
}
