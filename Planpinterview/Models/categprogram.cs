using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planpinterview.Models
{
    public class categprogram
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public double monyvalue { get; set; }

    }
}
