using Microsoft.AspNetCore.Mvc;
using template_identifier.Models;
using Microsoft.AspNet.OData;

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
