using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapiapp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        static Dictionary<int, string> values =
          new Dictionary<int, string> {
            { 0, "value0" },
            { 1, "value1" }
          };

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetValue")]
        public IActionResult Get(int id)
        {
          if (values.ContainsKey(id))
            return Ok(values[id]);
          else
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
          var nextId = values.Keys.Max() + 1;
          values[nextId] = value;
          return CreatedAtRoute("GetValue", new { id = nextId }, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
          values[id] = value;
          return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
          if (values.ContainsKey(id))
          {
            values.Remove(id);
            return NoContent();
          }
          else
            return NotFound();
        }
    }
}
