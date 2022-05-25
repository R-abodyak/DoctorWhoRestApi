using DoctorWho.DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public interface IEpisodeRebository
    {
        Task<IEnumerable<Episode>> GetAllEpisodeAsync();
        Task AddEpisodeAsync(Episode episode);
        Task SaveChanges();
        Task<bool> AddEnemyToEpisodeAsync(Enemy enemy ,int episodeId);
        Task<bool> AddCompanionToEpisodeAsync(Companion companion ,int episodeId);
    }
}
