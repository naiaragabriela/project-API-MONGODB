using apiMongoDB.Models;
using apiMongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<City>> Get() => _cityService.Get();

        [HttpGet("{id:length(24)}", Name ="GetClient")]
        public ActionResult<City>Get(string id)
        {
            var city = _cityService.Get(id);
            if(city == null) return NotFound();
            return city;
        }
    }
}
