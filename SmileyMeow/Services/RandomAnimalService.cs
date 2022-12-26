using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmileyMeow.DTOs;

namespace SmileyMeow.Services;

public class RandomAnimalService : IRandomAnimalService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;

    public RandomAnimalService(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }

    public async Task<RandomAnimalViewDTO> GetAnimalViewDTO()
    {
        Uri address = GetBaseURI();
        HttpClient _client = CreateHTTPClient();
        Task<RandomAnimalViewDTO> animalviewDTO = _client.GetFromJsonAsync<RandomAnimalViewDTO>($"{address}/GetRandomAnimal");

        RandomAnimalViewDTO result = await animalviewDTO;

        return result;
    }

    private HttpClient CreateHTTPClient()
    {
        return _clientFactory.CreateClient();

    }

    private Uri GetBaseURI()
    {

        return new Uri(_configuration.GetSection("RandomAnimalAPI:BaseURI").Value);
    }
}
