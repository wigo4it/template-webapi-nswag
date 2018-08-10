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
using AutoMapper;
using static template_identifier.Models.DTO.SampleModelDTO;

namespace template_identifier.Controllers
{
    public class SampleEfODataController : ODataController, ISampleController 
    {
        private ISampleController _implementation;

        public SampleEfODataController(DataContext context, ISampleController implementation)
        {
            _implementation = implementation;
        }

        [EnableQuery]
        public IActionResult Get(){ return _implementation.Get(); }
        [EnableQuery]
        public IActionResult Get(int key){return _implementation.Get(key); }  
    }
}
