using DoctorWho.DB.Models;
using DoctorWho.DB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorWho2.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController:ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var res = await _doctorService.GetAllDoctor();

            if( res == null )
            {
                return NotFound();
            }
            return Ok(res);

        }



    }
}
