using Microsoft.AspNetCore.Mvc;
using TodoApp_Back.API.Filters;
using TodoApp_Back.Application.Services.Interfaces;

namespace TodoApp_Back.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class HmacController : ControllerBase
    {
        private readonly IHmacService _hmacService;

        public HmacController(IHmacService hmacService)
        {
            _hmacService = hmacService;
        }

        [HttpPost("generate")]
        public IActionResult GenerateHmac([FromBody] string message)
        {
            var hmac = _hmacService.GenerateHmac(message);
            return Ok(new { Hmac = hmac });
        }

        [HttpPost("validate")]
        [AuthorizeHmac]
        public IActionResult ValidateHmac([FromBody] HmacValidationRequest request)
        {
            var isValid = _hmacService.ValidateHmac(request.Message, request.ReceivedHmac);
            return Ok(new { IsValid = isValid });
        }
    }
}
