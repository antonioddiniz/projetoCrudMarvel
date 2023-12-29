using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using projetoCrudMarvel.src.Dto;

namespace projetoCrudMarvel.src.Models
{
    public class Hero
    {

        public Hero(){}

        public Hero(CreateHero hero)
        {
            this.Name = hero.Name;
            this.RealName = hero.RealName;
            this.GroupId = hero.GroupId;
            this.CreatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(80)]
        [Required]
        public string Name { get; set; }
        [MaxLength(80)]
        [Required]
        public string RealName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? GroupId{get; set;}
        public Group group { get; set; }
    }
}