using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetoCrudMarvel.src.Dto;

namespace projetoCrudMarvel.src.Controllers
{
    [ApiController]
    [Route("api/v1/heroes")]
    public class HeroController
    {

        [HttpPost]
        public CreateHero Create(CreateHero hero){
            return hero;
        }
    }
}