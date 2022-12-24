using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAPI.Data;
using AnimalAPI.Models.Animall;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly ILogger<AnimalsController> _logger;
    private readonly AnimalAPIDbContext _context;

    public AnimalsController(ILogger<AnimalsController> logger, AnimalAPIDbContext context )
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("GetAllAnimals")]
    public async Task<IActionResult> GetAllAnimals() {
        List<Animal> allAnimals = await _context.Animals
        .Include(a => a.Specie)
        .Include(a => a.Breed)
        .ToListAsync();
        
        return Ok(allAnimals);
    }

    }
