using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using template_identifier.Models;
using static template_identifier.Models.SampleEfModel;
using AutoMapper;
using static template_identifier.Models.DTO.SampleModelDTO;
using App.Metrics;
using template_identifier.Metrics;

namespace template_identifier.Controllers
{
    [Route("api/[controller]")]
    public class SampleEfController : ControllerBase, ISampleController
    {
        private DataContext _db;
        
        public SampleEfController(DataContext context, IMetrics metrics)
        {
            Metrics = metrics;
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
        public IMetrics Metrics { get;set; }

        [HttpGet]
        public IActionResult Get()
        {
            using (Metrics.Measure.Timer.Time(SampleRegistry.GetBooksTimer))
            {
                return Ok(Mapper.Map<IEnumerable<BookDTO>>(_db.Books));
            }
        }

        [HttpGet]
        [Route("{key}")]
        public IActionResult Get(int key)
        {
            using (Metrics.Measure.Timer.Time(SampleRegistry.GetBookTimer))
            {
                return Ok(Mapper.Map<BookDTO>(_db.Books.FirstOrDefault(c => c.Id == key)));
            }
        }    
    }
}
