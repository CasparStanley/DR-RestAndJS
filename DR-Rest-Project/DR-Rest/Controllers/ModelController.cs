using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR_Rest.Managers;
using ModelLib;

namespace DR_Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IManager mgr;

        public ModelController(ModelContext context)
        {

            mgr = new ManagerDB(context);

        }
        // GET: api/<ItemController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            try
            {
                return Ok(mgr.Get());
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe);
            }
        }

        // GET api/<ItemController>/5
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(mgr.Get(id));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe);
            }
        }

        [HttpGet]
        [Route("Name/{substring}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFromSubstring(string substring)
        {
            try
            {
                return Ok(mgr.GetFromSubstring(substring));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe);
            }
        }

        [HttpGet]
        [Route("Quality/{quality}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFromSubstring(FilterItem filter)
        {
            try
            {
                return Ok(mgr.GetWithFilter(filter));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe);
            }
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetWithFilter([FromQuery] FilterItem filter)
        {
            try
            {
                return Ok(mgr.GetWithFilter(filter));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe);
            }
        }

        // POST api/<ItemController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post([FromBody] Model value)
        {
            try
            {
                return Ok(mgr.Create(value));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe);
            }

        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Model value)
        {
            
            try
            {
                return Ok(mgr.Update(id, value));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe);
            }
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            mgr.Delete(id);
        }
    }
}
