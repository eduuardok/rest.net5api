using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestNet5Api.Business;
using RestNet5Api.Data.VO;
using RestNet5Api.Hypermedia.Filters;

namespace RestNet5Api.Controllers
{
    [ApiController]
    [Authorize("Bearer")]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/book")]
    public class BookController : ControllerBase
    {
       private readonly ILogger<BookController> _logger;
       private IBookBusiness _BookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness BookBusiness)
        {
            _logger = logger;
            _BookBusiness = BookBusiness;
        }
        
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetAll(){

            return Ok(_BookBusiness.FindAll());

        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetByID(long id){

            var book = _BookBusiness.FindByID(id);

            if(book == null)
                return NotFound();

            return Ok(book);

        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book){

            if(book == null)
                return BadRequest();

            return Ok(_BookBusiness.Create(book));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book){

            if(book == null)
                return BadRequest();

            return Ok(_BookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id){
            _BookBusiness.Delete(id);

            return NoContent();
        }
    }
}