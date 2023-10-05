using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PHttpClienteFactory.Interface;
using PHttpClienteFactory.Models;

namespace PHttpClienteFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpCallController : ControllerBase
    {
        public readonly IHttpCallService _httpCallService;

        public HttpCallController(IHttpCallService httpCallService)
        {

            _httpCallService = httpCallService;
        }

        [HttpGet]
        [Route("GetData")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _httpCallService.GetData<DataModel>();
                return (response is null)?NotFound(response):Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
