using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.DB.Repositories
{
    public abstract class BaseRepository
    {
        public readonly DoctorWhoCoreDbContext _context;
        public BaseRepository(DoctorWhoCoreDbContext doctorWhoCoreDbContext)
        {
            _context = doctorWhoCoreDbContext;
        }
    }
}
