using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using template_identifier.Models;
using static template_identifier.Models.SampleEfModel;
using AutoMapper;
using static template_identifier.Models.DTO.SampleModelDTO;

namespace template_identifier.Controllers
{
    /// <summary>
    /// TODO: Implement https://github.com/xuzhg/OData.OpenAPI
    /// A project to convert an Edm (Entity Data Model) to OpenApi 3.0. Instead of writing this controller manually
    /// </summary>
    [Route("api/[controller]")]
    public class SampleEfController : ControllerBase, ISampleController
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Mapper.Map<IEnumerable<BookDTO>>(_db.Books));
        }
        [HttpGet]
        [Route("{key}")]
        public IActionResult Get(int key)
        {
            return Ok(Mapper.Map<BookDTO>(_db.Books.FirstOrDefault(c => c.Id == key)));
        }    
    }
}
