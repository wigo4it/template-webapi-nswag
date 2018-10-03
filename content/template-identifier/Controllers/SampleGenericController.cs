using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using template_identifier.Models;
using static template_identifier.Models.SampleEfModel;
using AutoMapper;
using static template_identifier.Models.DTO.SampleModelDTO;
using App.Metrics;
using template_identifier.Metrics;
using ProductService.Controllers;

namespace template_identifier.Controllers
{
    [Route("api/[controller]")]
    public class SampleGenericController : GenericController<Book>
    {
        public SampleGenericController(DataContext context, IMetrics metrics) : base(context, metrics)
        {
            System.Diagnostics.Debug.WriteLine("cool");
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
    }
}
