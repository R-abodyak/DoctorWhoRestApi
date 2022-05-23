using System;
using System. Collections. Generic;
using System. Text;

namespace DoctorWho. DB. Models
    {
    public class Enemy
        {
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }
        public ICollection<EpisodeEnemy> EpisodeEnemies { get; set; }
        }
    }
