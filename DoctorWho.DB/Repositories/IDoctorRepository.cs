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

        void UpdateDoctor(int id ,DoctorDto d);
        void DeleteDoctor(int id);
        public Task<List<Doctor>> GetAllDoctor();
    }
}
