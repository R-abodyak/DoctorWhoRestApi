using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.DB.Resources
{
    public class DoctorForUpdateDto
    {

        public int? DoctorNumber { get; set; }

        public string? DoctorName { get; set; }
        public DateTime BirthDate { get; set; }

        public DateTime FirstEpisodeDate { get; set; }
        public DateTime LastEpisodeDate { get; set; }


    }
}
