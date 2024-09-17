using AutoMapper;
using DoctorWho.DB.Models;
using DoctorWho.DB.Repositories;
using DoctorWho.DB.Resources;
using DoctorWho.DB.Validation;
using FluentValidation.Results;
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
        [HttpPost]
        public async Task<ActionResult<int>> CreateEpisode(EpisodeForCreateDto episode)
        {
            EpisodeForCreateDtoValidator validator = new EpisodeForCreateDtoValidator();

            ValidationResult results = validator.Validate(episode);
            var EpisodeEntity = _mapper.Map<Episode>(episode);
            await _episodeRepository.AddEpisodeAsync(EpisodeEntity);
            await _episodeRepository.SaveChanges();

            return Ok(EpisodeEntity.EpisodeId);
        }
        [HttpPost]
        [Route("{episodeId}/enemy/")]
        public async Task<ActionResult<Enemy>> AddEnemyToEpisodeAsync(
         int episodeId ,EnemyForCreateDto enemyToAdd)
        {
            var enemyEntity = _mapper.Map<Enemy>(enemyToAdd);
            var IsAdd = await _episodeRepository.AddEnemyToEpisodeAsync(enemyEntity ,episodeId);
            if( IsAdd == false )
            {
                return BadRequest("Episode doesn't exist");
            }
            await _episodeRepository.SaveChanges();
            EnemyForCreateDto result = _mapper.Map<EnemyForCreateDto>(enemyEntity);
            return Ok(result);

        }
        [HttpPost]
        [Route("{episodeId}/Companion/")]
        public async Task<ActionResult<Enemy>> AddCompanionToEpisodeAsync(
         int episodeId ,CompanionDto copanionToAdd)
        {
            var companionEntity = _mapper.Map<Companion>(copanionToAdd);
            var IsAdd = await _episodeRepository.AddCompanionToEpisodeAsync(companionEntity ,episodeId);
            if( IsAdd == false )
            {
                return BadRequest("Episode doesn't exist");
            }
            await _episodeRepository.SaveChanges();
            CompanionDto result = _mapper.Map<CompanionDto>(companionEntity);
            return Ok(result);

        }


    }
}
