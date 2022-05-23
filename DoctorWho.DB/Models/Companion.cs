using System;
using System. Collections. Generic;
using System. Text;

namespace DoctorWho. DB. Models
    {
    public class Companion
        {

        public int CompanionID { get; set; }
        public string CompanionName { get; set; }
        public string WhoPlayed { get; set; }

        //ref
        public ICollection<EpisodeCompanion> EpisodeCompanion { get; set; }

        }
    }
