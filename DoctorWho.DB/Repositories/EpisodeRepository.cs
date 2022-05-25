using DoctorWho.DB;
using DoctorWho.DB.Models;
using DoctorWho.DB.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public class EpisodeRepository:BaseRepository, IEpisodeRebository
    {
        public EpisodeRepository(DoctorWhoCoreDbContext doctorWhoCoreDbContext)
            : base(doctorWhoCoreDbContext)

        {
        }
        public async Task<IEnumerable<Episode>> GetAllEpisodeAsync()
        {
            var Episodes = await _context.Episodes.ToListAsync();
            return Episodes;

        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}