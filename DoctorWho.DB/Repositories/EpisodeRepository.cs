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
        public async Task AddEpisodeAsync(Episode episode)
        {
            await _context.Episodes.AddAsync(episode);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<bool> AddEnemyToEpisodeAsync(Enemy enemy ,int episodeId)
        {
            var episode = await _context.Episodes.FindAsync(episodeId);
            if( episode == null ) return false;
            await _context.AddAsync(new EpisodeEnemy { Enemy = enemy ,Episode = episode });
            return true;

        }

        public async Task<bool> AddCompanionToEpisodeAsync(Companion companion ,int episodeId)
        {
            var episode = await _context.Episodes.FindAsync(episodeId);
            if( episode == null ) return false;
            await _context.AddAsync(new EpisodeCompanion { Companion = companion ,Episode = episode });
            return true;

        }
    }
}