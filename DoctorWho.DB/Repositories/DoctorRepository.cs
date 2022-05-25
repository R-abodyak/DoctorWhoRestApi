using DoctorWho.DB.Models;
using DoctorWho.DB.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public class DoctorRepository:BaseRepository, IDoctorRepository
    {
        public DoctorRepository(DoctorWhoCoreDbContext doctorWhoCoreDbContext)
            : base(doctorWhoCoreDbContext)

        {
        }

        public async Task AddDoctor(Doctor doctor)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            var x = await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Doctors] ON");

            await _context.Doctors.AddAsync(doctor);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

        }

        public async Task UpdateDoctorAsync(int id ,Doctor d)
        {
            Doctor x = await FindDoctorByIdAsync(id);
            if( x == null ) throw new Exception();
            x.DoctorName = d.DoctorName;
            x.DoctorNumber = d.DoctorNumber;
            x.BirthDate = d.BirthDate;
            x.FirstEpisodeDate = d.FirstEpisodeDate;
            x.LastEpisodeDate = d.LastEpisodeDate;


        }

        public async Task<Doctor> FindDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            //DELETE DOCTOR ALSO DELETE RELATED EPISODE
            var x = await _context.Doctors.FindAsync(id);
            if( x == null ) return; //throw new Exception("id is not exist");
            _context.Doctors.Remove(x);

        }
        public async Task<IEnumerable<Doctor>> GetAllDoctorAsync()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
            // var d =context.Doctors.Select(s => s).ToList();



            ////
        }
        public IEnumerable<Doctor> GetAllDoctor()
        {
            var doctors = _context.Doctors.ToList();
            return doctors;
            // var d =context.Doctors.Select(s => s).ToList();



            ////
        }


    }
}
