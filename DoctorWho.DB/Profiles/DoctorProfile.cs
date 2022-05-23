using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DoctorWho.DB.Models;
using DoctorWho.DB.Resources;

namespace DoctorWho.DB.Profiles
{
    public class DoctorProfile:Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor ,DoctorDto>();
           
        }
    }
}
