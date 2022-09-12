using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{

    public class CharacterService : ICharacterService
    {
         private static List<character> characters = new List<character>(){
            new character(),
            new character { Id = 1, Name = "vipin"}
        };
        public async Task<ServiceResponse<List<character>>> AddCharacter(character newcharacter)
        {
            var ServiceResponse = new ServiceResponse<List<character>>();
              characters.Add(newcharacter);
    ServiceResponse.Data = characters;

         return  ServiceResponse;
        
        }

        public  async Task<ServiceResponse<List<character>>> GetAllCharacters()
        {
            return  new ServiceResponse<List<character>>{ Data = characters};
        }

        public async Task<ServiceResponse<character>> GetCharactersById(int id)
        {
            var ServiceRespons = new ServiceResponse<character>();
    var character =characters.FirstOrDefault(c=> c.Id == id);
    ServiceRespons.Data = character;
                return ServiceRespons;
    }
}
}