using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAPI.Models.AnimalInformationn;
using AnimalAPI.Models.Breedd;
using AnimalAPI.Models.Speciee;

namespace AnimalAPI.DTOs;

public record RandomAnimalResponse(
    int AnimalId,
    Specie Scepie,
    Breed Breed,
    AnimalInfo AnimalInfo
);
