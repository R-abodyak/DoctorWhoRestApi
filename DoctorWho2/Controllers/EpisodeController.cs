using AutoMapper;
using DoctorWho.DB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho2.Controllers
{

    [ApiController]
    [Route("api/doctors")]
    public class EpisodeController:ControllerBase
    {
        private readonly IEpisodeRebository _episodeRepository;
        private readonly IMapper _mapper;

        public EpisodeController(IEpisodeRebository episodeRepository ,IMapper mapper)
        {
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeDto>>> GetDoctors()
        {
            var EpisodeList = await _episodeRepository.GetAllDoctorAsync();

            if( EpisodeList == null )
            {
                return NotFound();
            }

            var EpisodeDtoList = _mapper.Map<IEnumerable<EpisodeDto>>(EpisodeList);
            return Ok(EpisodeDtoList);

        }

    }
}
