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


        [HttpPut("{DoctorId}")]
        public async Task<ActionResult<DoctorDto>> UpsertDoctor(int DoctorId ,DoctorForUpdateDto doctor)
        {
            DoctorForUpdateDtoValidator validator = new DoctorForUpdateDtoValidator();

            ValidationResult results = validator.Validate(doctor);
            var doctorEntity = _mapper.Map<Doctor>(doctor);
            doctorEntity.DoctorId = DoctorId;
            var doctor1 = await _doctorService.UpdateDoctor(DoctorId ,doctorEntity);
            //from configuration in setup for fluentvalidation.asp.NetCore ,
            //400 bad request  with error validatio msg will be result if there is any validation error 


            //else the code below will be excecute 

            if( doctor1 == null ) return NotFound();
            var DoctorDto = _mapper.Map<DoctorDto>(doctor1);
            return Ok(DoctorDto);
        }

        [HttpDelete("{DoctorId}")]
        public async Task<ActionResult<DoctorDto>> DeleteDoctor(int DoctorId)
        {
            var doctor = await _doctorService.DeleteDoctorAsync(DoctorId);
            if( doctor == null ) return NotFound();
            var doctorDto = _mapper.Map<DoctorDto>(doctor);
            return Ok(doctorDto);

        }


    }
}
