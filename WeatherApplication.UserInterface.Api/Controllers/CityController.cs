using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult GetCity(GetCityRequest request)
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
        public IActionResult AddCity(AddCityRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.AddCityAsync(request);
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
        public IActionResult DeleteCity(DeleteCityRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.DeleteCityAsync(request);
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
    }
}
