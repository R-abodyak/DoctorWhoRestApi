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
        public void DeleteDoctor(int id);
        public Task<IEnumerable<Doctor>> GetAllDoctorAsync();
        public IEnumerable<Doctor> GetAllDoctor();
    }
}
