using DoctorWho.DB.Models;
using DoctorWho.DB.Resurces;
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

        public void AddDoctor(Doctor doctor)
        {

            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void UpdateDoctor(int id ,DoctorDto d)
        {

            var x = _context.Doctors.Find(id);
            if( x == null ) throw new Exception("id is not exist");
            x.DoctorName = d.DoctorName;

            x.BirthDate = DateTime.Now;
            x.FirstEpisodeDate = new DateTime(1900 ,04 ,16);
            x.LastEpisodeDate = new DateTime(2030 ,11 ,11);

            _context.SaveChanges();
        }
        public void DeleteDoctor(int id)
        {
            //DELETE DOCTOR ALSO DELETE RELATED EPISODE
            var x = _context.Doctors.Find(id);
            if( x == null ) return; //throw new Exception("id is not exist");
            _context.Doctors.Remove(x);
            _context.SaveChanges();

        }
        public async Task<List<Doctor>> GetAllDoctor()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
            // var d =context.Doctors.Select(s => s).ToList();
        }
    }
}
