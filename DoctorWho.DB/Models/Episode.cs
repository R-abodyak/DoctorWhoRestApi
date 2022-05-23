using System;
using System. Collections. Generic;
using System. Text;

namespace DoctorWho. DB. Models
    {
    public class Episode
        {
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Tittle { get; set; }
        public DateTime EpisodeDate { get; set; }
        public string Notes { get; set; }

        //FK for Doctor 
        public int DoctorId { get; set; }


        //references for relations
        public Author Author { get; set; }
        public Doctor Doctor { get; set; }

        public ICollection<EpisodeCompanion> EpisodeCompanion { get; set; }
        public ICollection<EpisodeEnemy> EpisodeEnemies { get; set; }


        }
    }
