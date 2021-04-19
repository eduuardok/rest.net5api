using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestNet5Api.Model;
using RestNet5Api.Business;
using RestNet5Api.Data.VO;
using RestNet5Api.Hypermedia.Filters;

namespace RestNet5Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/pessoa")]
    public class PersonController : ControllerBase
    {
       private readonly ILogger<PersonController> _logger;
       private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }
        
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetAll(){

            return Ok(_personBusiness.FindAll());

        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetByID(long id){

            var person = _personBusiness.FindByID(id);

            if(person == null)
                return NotFound();

            return Ok(person);

        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person){

            if(person == null)
                return BadRequest();

            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person){

            if(person == null)
                return BadRequest();

            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id){
            _personBusiness.Delete(id);

            return NoContent();
        }
    }
}