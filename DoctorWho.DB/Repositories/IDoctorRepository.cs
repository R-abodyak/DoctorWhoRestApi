using DoctorWho.DB.Models;
using DoctorWho.DB.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public interface IDoctorRepository
    {
        Task AddDoctor(Doctor doctor);
        Task<Doctor> FindDoctorByIdAsync(int id);
        Task UpdateDoctor(int id ,Doctor d);
        void DeleteDoctor(int id);
        public Task<IEnumerable<Doctor>> GetAllDoctorAsync();
        public IEnumerable<Doctor> GetAllDoctor();
    }
}
