using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using template_identifier.Models;
using System.Net;
using System.Web.Http;
using Microsoft.AspNet.OData;
using static template_identifier.Models.SampleEfModel;

namespace template_identifier.Controllers
{
    public class SampleEfController : ODataController
    {
         private DataContext _db;

        public SampleEfController(DataContext context)
        {
            _db = context;
            if (context.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Books);
        }
        /*

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_db.Books.FirstOrDefault(c => c.Id == key));
        } 
        */    
    }
}
