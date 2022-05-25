using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public abstract class BaseRepository
    {
        public readonly DoctorWhoCoreDbContext _context;
        public BaseRepository(DoctorWhoCoreDbContext doctorWhoCoreDbContext)
        {
            _context = doctorWhoCoreDbContext;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
