using AutoMapper;
using DoctorWho.DB.Models;
using DoctorWho.DB.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.DB.Profiles
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorDto ,Author>();
            CreateMap<Author ,AuthorDto>();
        }
    }
}
