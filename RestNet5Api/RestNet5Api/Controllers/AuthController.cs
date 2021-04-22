using Microsoft.AspNetCore.Mvc;
using RestNet5Api.Business;
using RestNet5Api.Data.VO;

namespace RestNet5Api.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }
        
        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user){
            if(user == null)
                return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(user);

            if(token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}