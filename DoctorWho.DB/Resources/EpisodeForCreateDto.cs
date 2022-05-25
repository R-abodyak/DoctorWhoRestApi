using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.DB.Resources
{
    public class EpisodeForCreateDto
    {

        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Tittle { get; set; }
        public DateTime EpisodeDate { get; set; }
        public string Notes { get; set; }
        public int DoctorId { get; set; }
        public int AuthorId { get; set; }

    }
}
