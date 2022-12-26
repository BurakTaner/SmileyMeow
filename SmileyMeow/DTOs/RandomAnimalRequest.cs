using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Animall;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.Speciee;

namespace SmileyMeow.DTOs;


public record RandomAnimalResponse(
    int AnimalId,
    Specie Scepie,
    Breed Breed,
    AnimalInfo AnimalInfo
);