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
        public void AddEnemyToEpisode(Enemy enemy ,int episodeId)
        {
            var episode = _context.Episodes.Find(episodeId);
            if( episode == null ) return;

            _context.Add(new EpisodeEnemy { Enemy = enemy ,Episode = episode });

        }
        public void AddCompanionToEpisode(Companion companion ,Episode episode)
        {
            _context.Add(new EpisodeCompanion { Companion = companion ,Episode = episode });

        }
    }
}