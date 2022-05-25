using DoctorWho.DB.Models;
using DoctorWho.DB.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorWho.DB.Services
{
    public interface IDoctorService
    {
        public Task AddDoctor(Doctor doctor);
        public Task<Doctor> UpdateDoctor(int id ,Doctor d);

        public Task<Doctor> DeleteDoctorAsync(int id);
        public Task<IEnumerable<Doctor>> GetAllDoctorAsync();
        public IEnumerable<Doctor> GetAllDoctor();
    }
}
