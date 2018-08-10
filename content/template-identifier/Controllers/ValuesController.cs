using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using template_identifier.Models;

namespace template_identifier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Get values
        /// </summary>
        /// <returns>Values</returns>
        [HttpGet]
        [Description("Get values")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Description("Get value by providing an Id")]
        public ActionResult<string> Get(int id)
        {
            using (ValueContext ctx = new ValueContext(null))
            {
                return ctx.Values.FirstOrDefault(p=>p.Id==id).Val;
            }
        }

        // POST api/values
        [HttpPost]
        [Description("Post a new value")]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Description("Update a value by providing its Id")]
        public void Put(int id, [FromBody] string value)
        {
        }
        
        [Description("Delete a value by providing its Id")]
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
