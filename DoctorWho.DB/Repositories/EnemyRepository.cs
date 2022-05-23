using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.DB.Repositories
    {
    public class EnemyRepository
        {
        static DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();

        public static void AddEnemy(Enemy enemy)
            {
            var x = context.Add(enemy);
            context.SaveChanges();
            }
        }
    }
