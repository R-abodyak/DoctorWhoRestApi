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
        Task SaveChanges();
    }
}
