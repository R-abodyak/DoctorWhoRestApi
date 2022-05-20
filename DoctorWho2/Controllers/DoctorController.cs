using AutoMapper;
using DoctorWho.DB.Models;
using DoctorWho.DB.Resources;
using DoctorWho.DB.Services;
using DoctorWho.DB.Validation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

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
        [HttpGet("{DoctorId}")]
        public async Task<ActionResult<DoctorDto>> GetDoctor(int DoctorId)
        {
            var DoctorList = await _doctorService.GetDoctor(DoctorId);

            if( DoctorList == null )
            {
                return NotFound();
            }


            return Ok(DoctorList);

        }

        [HttpPut("{DoctorId}")]
        public async Task<ActionResult<DoctorDto>> UpsertDoctor(int DoctorId ,DoctorForUpdateDto doctor)
        {
            DoctorForUpdateDtoValidator validator = new DoctorForUpdateDtoValidator();

            ValidationResult results = validator.Validate(doctor);
            BadRequestResult x = BadRequest();
            if( !ModelState.IsValid )
            {
                ModelState.AddModelError("error" ,"error");
                return BadRequest(ModelState);


            }

            //how to send errors? ...lets see
            var doctor1 = await _doctorService.UpdateDoctor(DoctorId ,doctor);
            //this need to create new instance 
            if( doctor1 == null ) return NotFound();
            var DoctorDto = _mapper.Map<DoctorDto>(doctor1);
            return Ok(DoctorDto);
        }




    }
}
