using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
       Task<ServiceResponse<List<character>>> GetAllCharacters();
       Task<ServiceResponse<character>> GetCharactersById(int id);
       Task<ServiceResponse<List<character>>> AddCharacter(character newcharacter);
    }
}