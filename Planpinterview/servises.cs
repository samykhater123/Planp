using Planpinterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace Planpinterview
{
    public class servises
    {
        private readonly appdbcontext _db;

        public servises(appdbcontext db)
        {
            db = _db;
        }

        
        public ActionResult<double> getmonyvalueAsync(int id)
        {
            //IEnumerable<double> mony = from m in _db.categprogram
            //           .Where(x => x.id == id)
            //           select m.monyvalue;

            var mm = _db.categprogram.Where(x => x.id == id).FirstOrDefault().monyvalue;
             
            return  mm;
        }
    }
}
