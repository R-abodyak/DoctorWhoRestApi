using DoctorWho.DB.Models;
using DoctorWho.DB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;
using DoctorWho.DB.Resources;
using System;

namespace DoctorWho2.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController:ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService ,IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            var DoctorList = await _doctorService.GetAllDoctorAsync();

            if( DoctorList == null )
            {
                return NotFound();
            }

            var DoctorDtoList = _mapper.Map<IEnumerable<DoctorDto>>(DoctorList);
            return Ok(DoctorDtoList);

        }


        //[HttpPut("{DoctorId}")]
        //public IActionResult UpsertDoctor(Guid DoctorId ,DoctorForUpdateDto course)
        //{

        //}




    }
}
