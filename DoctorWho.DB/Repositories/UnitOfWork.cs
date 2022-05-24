using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DoctorWhoCoreDbContext _doctorWhoCoreDbContext;

        public UnitOfWork(DoctorWhoCoreDbContext doctorWhoCoreDbContext)
        {
            _doctorWhoCoreDbContext = doctorWhoCoreDbContext;
        }
        public async Task CompleteAsync()
        {
            await _doctorWhoCoreDbContext.SaveChangesAsync();
            return;
        }
    }
}
