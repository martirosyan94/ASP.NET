using CoreCodeCamp.Data;
using CoreCodeCamp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using System;
using System.Linq;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository _campRepository;
        private readonly IMapper _mapper;

        public CampsController(ICampRepository campRepository, IMapper mapper)
        {
            _campRepository = campRepository;
            _mapper = mapper;
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
                CampModel[] models = _mapper.Map<CampModel[]>(results);
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

                return _mapper.Map<CampModel>(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<CampModel[]>> SearchByDate(DateTime theDate, bool includeTalks = false)
        {
            try
            {
                var results = await _campRepository.GetAllCampsByEventDate(theDate, includeTalks);

                if (!results.Any()) return NotFound();

                return _mapper.Map<CampModel[]>(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("addCamp")]
        public async Task<ActionResult<CampModel>> AddCamp(CampModel campModel)
        {
            try
            {
                var existing = await _campRepository.GetCampAsync(campModel.Moniker);
                if (existing is not null)
                    return BadRequest($"The camp with the {campModel.Moniker} already exist, try reg another");

                Camp newCamp = _mapper.Map<Camp>(campModel);
                _campRepository.Add(newCamp);

                if (await _campRepository.SaveChangesAsync())
                    return Created("", newCamp);

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpPut("update/{moniker}")]
        public async Task<ActionResult<CampModel>> UpdateByMoniker(string moniker, CampModel campModel)
        {
            try
            {
                var oldCamp = await _campRepository.GetCampAsync(moniker);
                if (oldCamp is null) return NotFound($"Camp with the {moniker} name does not exist");

                _mapper.Map(campModel, oldCamp);

                if (await _campRepository.SaveChangesAsync())
                    return campModel;

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpDelete("remove/{moniker}")]
        public async Task<ActionResult> RemoveCamp(string moniker)
        {
            try
            {
                var exisingCamp = await _campRepository.GetCampAsync(moniker);
                if (exisingCamp is null) return NotFound();

                _campRepository.Delete(exisingCamp);
                if (await _campRepository.SaveChangesAsync()) return Ok();
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

    }
}
