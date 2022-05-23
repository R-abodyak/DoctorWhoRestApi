using System;
using System. Collections. Generic;
using System. Text;

namespace DoctorWho. DB. Models
    {
    public class EpisodeEnemy
        {
        public int EpisodeEnemyId { get; set; }
        public int EpisodeId { get; set; }
        public int EnemyID { get; set; }
        public Episode Episode { get; set; }
        public Enemy Enemy { get; set; }


        }
    }
