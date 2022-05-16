using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Internal;
namespace Planpinterview.Models
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public DateTime date { get; set; }

        public int categprogramid { get; set; }
        public categprogram categprogram { get; set; }

        public double monyvalue { get; set; }
    }
}
