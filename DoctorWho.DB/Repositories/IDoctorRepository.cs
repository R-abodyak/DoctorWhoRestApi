using DoctorWho.DB.Models;
using DoctorWho.DB.Resurces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public interface IDoctorRepository
    {
        void AddDoctor(Doctor doctor);
        Task<Doctor> FindDoctorByIdAsync(int id);
        void UpdateDoctor(int id ,DoctorDto d);
        void DeleteDoctor(int id);
        public Task<IEnumerable<Doctor>> GetAllDoctorAsync();

    }
}
