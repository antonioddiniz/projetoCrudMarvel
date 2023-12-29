using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using projetoCrudMarvel.src.Dto;

namespace projetoCrudMarvel.src.Models
{
    public class Group
    {
        
        public Group(){}

        public Group(CreateGroup group)
        {
            this.Name = group.Name;
        }
        
        
        
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }


    }
}