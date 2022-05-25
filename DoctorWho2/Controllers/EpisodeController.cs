using AutoMapper;
using DoctorWho.DB.Repositories;
using DoctorWho.DB.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorWho2.Controllers
{

    [ApiController]
    [Route("api/episodes")]
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
        public async Task<ActionResult<IEnumerable<EpisodeDto>>> GetEpisodes()
        {
            var EpisodeList = await _episodeRepository.GetAllEpisodeAsync();

            if( EpisodeList == null )
            {
                return NotFound();
            }

            var EpisodeDtoList = _mapper.Map<IEnumerable<EpisodeDto>>(EpisodeList);
            return Ok(EpisodeDtoList);

        }

    }
}
