using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class charectercontroller : ControllerBase
    {
        private static List<character> knight = new List<character>(){
            
        };

        [HttpGet]
        public ActionResult<character> Get()
        {
            return Ok(knight) ;
        }
        
    }
}