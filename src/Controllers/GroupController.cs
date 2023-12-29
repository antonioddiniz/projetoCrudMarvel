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
    [Route("api/v1/groups")]
    public class GroupController : ControllerBase
    {
        private readonly DataContext _context;

        public GroupController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public Group Create(CreateGroup group)
        {
            var newGroup = new Group(group);

            _context.Groups.Add(newGroup);
            _context.SaveChanges();
            
            return newGroup;
        }

        [HttpPut("updategroup/{id}")]
        public IActionResult UpdateGroup(int id, CreateGroup group)
        {
            var groupDto = new Group(group);
            var groupData = _context.Groups.Find(id);

            if(groupData == null)
                return NotFound();

            groupData.Name = groupDto.Name;

            _context.Groups.Update(groupData);
            _context.SaveChanges();

            return Ok(groupData);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var group = _context.Groups.Find(id);
            if(group == null)
                return NotFound();

            return Ok(group);
        }

        [HttpGet("getbyname/{name}")]
        public IActionResult GetByName(string name)
        {
            var group = _context.Groups.Where(x => x.Name.Contains(name));
            if(group == null)
                return NotFound();

            return Ok(group);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteGroup(int id)
        {
            var groupData = _context.Groups.Find(id);

            if(groupData == null)
                return NotFound();

            _context.Groups.Remove(groupData);
            _context.SaveChanges();

            return NoContent();


        }


    }
}