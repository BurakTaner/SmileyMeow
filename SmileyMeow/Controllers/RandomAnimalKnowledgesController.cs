using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmileyMeow.DTOs;
using SmileyMeow.Services;

namespace SmileyMeow.Controllers;
public class RandomAnimalKnowledgesController : BasyController
{
    private readonly ILogger<RandomAnimalKnowledgesController> _logger;
    private readonly IRandomAnimalService _randomAnimalService;

    public RandomAnimalKnowledgesController(ILogger<RandomAnimalKnowledgesController> logger, IRandomAnimalService randomAnimalService)
    {
        _logger = logger;
        _randomAnimalService = randomAnimalService;
    }

    public async Task<IActionResult> Index()
    {
        RandomAnimalResponse response =  await _randomAnimalService.GetAnimalViewDTO();

        RandomAnimalViewDTO dto = new(
            response.AnimalId,
            response.Scepie.SName,
            response.Breed.BName,
            response.AnimalInfo.AnimalInformation
        );
        return View(dto);
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View("Error!");
    // }
}
