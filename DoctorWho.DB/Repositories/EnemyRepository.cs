using DoctorWho.DB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.DB.Repositories
{
    public class EnemyRepository:BaseRepository
    {
        public EnemyRepository(DoctorWhoCoreDbContext doctorWhoCoreDbContext) : base(doctorWhoCoreDbContext)
        {
        }

        public void AddEnemy(Enemy enemy)
        {
            var x = _context.Add(enemy);
            _context.SaveChanges();
        }
    }
}
