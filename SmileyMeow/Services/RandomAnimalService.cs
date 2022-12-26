using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmileyMeow.DTOs;

namespace SmileyMeow.Services;

public class RandomAnimalService : IRandomAnimalService
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;

    public RandomAnimalService(HttpClient client, IConfiguration configuration)
    {
        _client = client;
        _configuration = configuration;
    }

    public RandomAnimalViewDTO GetAnimalViewDTO()
    {
        Uri address = GetBaseURI();

        RandomAnimalViewDTO animalviewDTO = _client.GetFromJsonAsync<RandomAnimalViewDTO>($"{address}/GetRandomAnimal").Result; 
        
        return animalviewDTO ;
    }

    private Uri GetBaseURI()
    {
        return _client.BaseAddress = new Uri(_configuration.GetSection("RandomAnimalAPI:BaseURI").Value);
    }
}
