using System;
using System. Collections. Generic;
using System. Text;

namespace DoctorWho. DB. Models
    {
    public class EpisodeCompanion
        {
        public int EpisodeCompanionId { get; set; }
        public int EpisodeId { get; set; }
        public int CompanionID { get; set; }

        public Episode Episode { get; set; }
        public Companion Companion { get; set; }
        }
    }
