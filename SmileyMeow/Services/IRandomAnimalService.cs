using SmileyMeow.DTOs;

namespace SmileyMeow.Services;

public interface IRandomAnimalService
{
    Task<RandomAnimalViewDTO> GetAnimalViewDTO();
}
