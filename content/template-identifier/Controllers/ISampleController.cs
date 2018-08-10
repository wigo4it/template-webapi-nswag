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
    /// <summary>
    /// TODO: Implement https://github.com/xuzhg/OData.OpenAPI
    /// A project to convert an Edm (Entity Data Model) to OpenApi 3.0. Instead of writing this controller manually
    /// </summary>
    public interface ISampleController
    {
        IActionResult Get();
        IActionResult Get(int key);

    }
}
