using DoctorWho. DB. Models;
using System;
using System. Collections. Generic;
using System. Text;

namespace DoctorWho. DB. Resurces
    {
    public class DoctorDto
        {
        public int DoctorNumber { get; set; }

        public string DoctorName { get; set; }
        public DateTime BirthDate { get; set; }

        public DateTime FirstEpisodeDate { get; set; }
        public DateTime LastEpisodeDate { get; set; }

        //
        public ICollection<Episode> Episodes { get; set; }
        }
    }
