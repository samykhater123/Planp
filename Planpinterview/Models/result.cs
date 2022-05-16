using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planpinterview.Models
{
    public class result
    {
        [Key]
        public int id { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public double totalmony { get; set; }
        public int totalplayers { get; set; }
    }
}
