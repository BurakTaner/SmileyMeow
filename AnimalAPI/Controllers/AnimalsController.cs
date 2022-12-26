using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAPI.Data;
using AnimalAPI.DTOs;
using AnimalAPI.Helpers;
using AnimalAPI.Models.Animall;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly ILogger<AnimalsController> _logger;
    private readonly AnimalAPIDbContext _context;

    public AnimalsController(ILogger<AnimalsController> logger, AnimalAPIDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("GetRandomAnimal")]
    public async Task<IActionResult> GetRandomAnimal()
    {
        Animal randomAnimal = await _context.Animals
        .Include(a => a.Specie)
        .Include(a => a.Breed)
        .Include(a => a.AnimalInfo)
        .FirstOrDefaultAsync(a => a.AnimalId == RandomNumberGenerator.RandomNumberGenerate());
        
        if (randomAnimal == null)
        {
            return NotFound();
        }

        RandomAnimalResponse randomAnimalDTO = CreateAnimalResponse(randomAnimal);
        
        return Ok(randomAnimalDTO);
    }

    private static RandomAnimalResponse CreateAnimalResponse(Animal randomAnimal)
    {
        return new(
                    randomAnimal.AnimalId,
                    randomAnimal.Specie,
                    randomAnimal.Breed,
                    randomAnimal.AnimalInfo
                );
    }
}
