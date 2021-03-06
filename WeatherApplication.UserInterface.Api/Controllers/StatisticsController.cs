using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeatherApplication.Domain.Interfaces;
using WeatherApplication.Domain.Interfaces.RequestModels.Statistics;

namespace WeatherApplication.UserInterface.Api.Controllers
{
    [Route("[controller]")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsRepo repository;

        public StatisticsController(IStatisticsRepo repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetStatisticsAndCurrentConditionsInCityFromCacheOrCalculateAndSetCache(GetStatisticsRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var statistics = repository.GetStatisticsAndCurrentConditions(request);
                    return Ok(statistics);
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

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllStatisticalModelsOfCity(GetStatisticsRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var statistics = repository.GetAllStatisticalModelsOfCity(request);
                    return Ok(statistics);
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
        public async Task<IActionResult> SaveStatisticsAndCurrentConditionsInCityAndCacheIt(SaveStatisticsRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.SaveStatisticsAndCurrentConditionsAsync(request);
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
        public async Task<IActionResult> DeleteStatisticalModel(DeleteStatisticsRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.DeleteStatisticalModelAsync(request);
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
