using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeatherApplication.Domain.Interfaces;
using WeatherApplication.Domain.Interfaces.RequestModels.Weather;

namespace WeatherApplication.UserInterface.Api.Controllers
{
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherRepo repository;

        public WeatherController(IWeatherRepo repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetWeatherHistoryOfCity(GetWeatherHistoryRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var weatherHistory = repository.GetWeatherHistoryOfCity(request);
                    return Ok(weatherHistory);
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
        public async Task<IActionResult> CreateWeatherModel(AddWeatherRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.AddWeatherAsync(request);
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

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> EditWeatherModelAtCertainTime(EditWeatherRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.EditWeatherAtCertainTimeAsync(request);
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
        public async Task<IActionResult> DeleteWeatherModelAtCertainTime(DeleteWeatherRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.DeleteWeatherAtCertainTimeAsync(request);
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

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ArchivePartOfWeatherHistoryOfCity(ArchiveWeatherRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.ArchiveWeatherInfoOfCityAsync(request);
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
        public IActionResult DeleteArchivedDataOfCity(DeleteArchivedDataRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.DeleteAllArchivedWeatherInfoOfCityAsync(request);
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
