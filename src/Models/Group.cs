using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCrudMarvel.src.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


    }
}