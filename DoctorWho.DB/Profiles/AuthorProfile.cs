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
