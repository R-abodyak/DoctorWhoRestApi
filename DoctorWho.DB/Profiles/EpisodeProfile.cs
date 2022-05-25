using AutoMapper;
using DoctorWho.DB.Models;
using DoctorWho.DB.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.DB.Profiles
{
    public class EpisodeProfile:Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Episode ,EpisodeDto>();
            CreateMap<EpisodeForCreateDto ,Episode>();



        }
    }
}
