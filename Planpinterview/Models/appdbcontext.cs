using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planpinterview.Models;

namespace Planpinterview.Models
{
    public class appdbcontext:DbContext
    {
        public appdbcontext(DbContextOptions<appdbcontext>options):base (options)
        {

        }

        public DbSet<Player> players { get; set; }

        public DbSet<Planpinterview.Models.categprogram> categprogram { get; set; }

        public DbSet<Planpinterview.Models.result> result { get; set; }
    }
}
