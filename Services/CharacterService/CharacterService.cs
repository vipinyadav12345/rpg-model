using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dto;
using dotnet_rpg.Dto.Character;
using dotnet_rpg.models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Services.CharacterService
{

    public class CharacterService : ICharacterService
    {
        
       //  private static List<character> characters = new List<character>(){
        //    new character(),
         //   new character { Id = 1, Name = "vipin"}
      //  };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext  context)
         {

            _mapper = mapper;
            _context = context;
        }
      
 public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            character character =  _mapper.Map <character>(newCharacter);
            _context.character.Add(character);
            await  _context.SaveChangesAsync();
            //characters.Add(_mapper.Map <character>(newCharacter));
            serviceResponse.Data =  await  _context.character.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>>DeletCharacter(int id)
        {
           // throw new NotImplementedException(); 
               ServiceResponse<List<GetCharacterDto>> response = new  ServiceResponse<List<GetCharacterDto>>();

            try {
            character  Character =  await _context.character.FirstAsync(c => c.Id == id);
           // _mapper.Map(updateCharacter, Character );

         _context.character.Remove(Character);
          await  _context.SaveChangesAsync();
         response.Data = _context.character.Select( c => _mapper.Map<GetCharacterDto>(c)).ToList();
      }
            catch (Exception ex)
       {
        response.success = false ;
        response.Message = ex.Message;
       
        }

        return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response =  new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacter = await _context.character.ToListAsync();
            response.Data = dbCharacter.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            return response;
         //   return new ServiceResponse<List<GetCharacterDto>> 
           // {Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList() };
        }

         public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {

            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter =  await _context.character.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacte(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new  ServiceResponse<GetCharacterDto>();

            try {
           var Character =  await _context.character
            .FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);
           // _mapper.Map(updateCharacter, Character );

         Character.Name  = updateCharacter.Name;
         Character.Hitpoints = updateCharacter.Hitpoints;
         Character.stringth =  updateCharacter.stringth ;
        Character.defence =  updateCharacter.defence;
        Character.inteligence =  updateCharacter.inteligence;
        Character.Class =  updateCharacter.Class ;
         await  _context.SaveChangesAsync();

        response.Data = _mapper.Map<GetCharacterDto>(Character);
      }
            catch (Exception ex)
       {
        response.success = false ;
        response.Message = ex.Message;
       
        }

        return response;
    }

       
    }
}
