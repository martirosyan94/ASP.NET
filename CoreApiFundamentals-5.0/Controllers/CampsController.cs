using CoreCodeCamp.Data;
using CoreCodeCamp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository _campRepository;
        private readonly IMapper _mapping;

        public CampsController(ICampRepository campRepository, IMapper mapping)
        {
            _campRepository = campRepository;
            _mapping = mapping;
        }

        [HttpGet("ping")]
        public string[] Get()
        {
            return new[] { "Hello", "From", "Pluralsight" };
        }

        [HttpGet]
        public async Task<ActionResult<CampModel[]>> GetAllCamps(bool includeTalks)
        {
            try
            {
                var results = await _campRepository.GetAllCampsAsync(includeTalks);
                CampModel[] models = _mapping.Map<CampModel[]>(results);
                return models;
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{moniker}")]
        public async Task<ActionResult<CampModel>> GetByMoniker(string moniker)
        {
            try
            {
                var result = await _campRepository.GetCampAsync(moniker);

                if (result is null) return NotFound();

                return _mapping.Map<CampModel>(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
