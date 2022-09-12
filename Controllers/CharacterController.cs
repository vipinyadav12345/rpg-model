using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
       
      private readonly ICharacterService  _characterService;
      public  CharacterController(ICharacterService characterService)
      {
            _characterService = characterService;

      }

        [Route("GetAll")]
        [HttpGet]

        public  async Task<ActionResult<ServiceResponse<List<character>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<character>>>Getsingle(int id)
        {
            return Ok(await _characterService.GetCharactersById(id));

}
        [HttpPost]
         public  async Task<ActionResult<List<ServiceResponse<character>>>> AddCharacter( character NewCharacter ){
         return Ok(await _characterService.AddCharacter(NewCharacter));
         }


    }
}