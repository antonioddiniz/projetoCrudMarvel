using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moduloAPI.Context;
using projetoCrudMarvel.src.Dto;
using projetoCrudMarvel.src.Models;

namespace projetoCrudMarvel.src.Controllers
{
    [ApiController]
    [Route("api/v1/heroes")]
    public class HeroController: ControllerBase
    {
        private readonly DataContext _context;

        public HeroController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public Hero Create(CreateHero hero){
            var newHero = new Hero(hero);

            _context.Heroes.Add(newHero);
            _context.SaveChanges();

            return newHero;
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateHero(int id, CreateHero hero)
        {
            var heroDto = new Hero(hero);
            var heroData = _context.Heroes.Find(id);

            if(heroData == null)
                return NotFound();

            heroData.Name = heroDto.Name;
            heroData.RealName = heroDto.RealName;
            heroData.GroupId = heroDto.GroupId;

            _context.Heroes.Update(heroData);
            _context.SaveChanges();

            return Ok(heroData);

        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {

            var hero = _context.Heroes.Find(id);
            if(hero == null)
                return NotFound();
            return Ok(hero);
        }

        [HttpGet("getbyname/{name}")]
        public IActionResult GetByName(string name)
        {
            var hero = _context.Heroes.Where(x => x.Name.Contains(name));
            if(hero == null)
                return NotFound();
            return Ok(hero);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteHero(int id)
        {
            var heroData = _context.Heroes.Find(id);

            if(heroData == null)
                return NotFound();

            _context.Heroes.Remove(heroData);
            _context.SaveChanges();

            return NoContent();
        }

    }
}