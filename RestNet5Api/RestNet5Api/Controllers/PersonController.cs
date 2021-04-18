using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestNet5Api.Model;
using RestNet5Api.Business;

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
        public IActionResult GetAll(){

            return Ok(_personBusiness.FindAll());

        }

        [HttpGet("{id}")]
        public IActionResult GetByID(long id){

            var person = _personBusiness.FindByID(id);

            if(person == null)
                return NotFound();

            return Ok(person);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person){

            if(person == null)
                return BadRequest();

            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person){

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