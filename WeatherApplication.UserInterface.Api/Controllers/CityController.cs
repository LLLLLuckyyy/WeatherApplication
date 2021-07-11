using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeatherApplication.Domain.Interfaces;
using WeatherApplication.Domain.Interfaces.RequestModels.City;

namespace WeatherApplication.UserInterface.Api.Controllers
{
    [Route("[controller]")]
    public class CityController : Controller
    {
        private readonly ICityRepo repository;

        public CityController(ICityRepo repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Get(GetCityRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var city = repository.GetCity(request);
                    return Ok(city);
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(AddCityRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.AddCityAsync(request);
                    return Ok();
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(DeleteCityRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.DeleteCityAsync(request);
                    return NoContent();
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
