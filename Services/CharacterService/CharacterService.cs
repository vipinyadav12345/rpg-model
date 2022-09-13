using AutoMapper;
using dotnet_rpg.Dto;
using dotnet_rpg.Dto.Character;
using dotnet_rpg.models;

namespace dotnet_rpg.Services.CharacterService
{

    public class CharacterService : ICharacterService
    {
        
         private static List<character> characters = new List<character>(){
            new character(),
            new character { Id = 1, Name = "vipin"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
         {
            _mapper = mapper;
        }
      

        public async  Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {

            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            character character =  _mapper.Map <character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            //characters.Add(_mapper.Map <character>(newCharacter));
            serviceResponse.Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

         public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDto>> {Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList() };
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacte(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new  ServiceResponse<GetCharacterDto>();

            try {
            character Character =  characters.FirstOrDefault(c => c.Id == updateCharacter.Id);
            _mapper.Map(updateCharacter, Character );
        // Character.Name  = updateCharacter.Name;
        // Character.Hitpoints = updateCharacter.Hitpoints;
         //Character.stringth =  updateCharacter.stringth ;
        //Character.defence =  updateCharacter.defence;
        //Character.inteligence =  updateCharacter.inteligence;
       // Character.Class =  updateCharacter.Class ;
        response.Data = _mapper.Map<GetCharacterDto>(Character);
            }catch (Exception ex)
       {
        response.success = false ;
        response.Message = ex.Message;
       
        }

        return response;
    }

       
    }
}
