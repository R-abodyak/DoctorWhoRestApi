using DoctorWho.DB.Models;
using DoctorWho.DB.Repositories;
using DoctorWho.DB.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DoctorWho.DB.Services
{
    public class DoctorService:IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IDoctorRepository doctorRepository ,IUnitOfWork unitOfWork)
        {
            _doctorRepository = doctorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddDoctor(Doctor doctor)
        {
            await _doctorRepository.AddDoctor(doctor);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Doctor> DeleteDoctorAsync(int id)
        {
            var x = await _doctorRepository.FindDoctorByIdAsync(id);

            if( x == null ) return null;
            await _doctorRepository.DeleteDoctorAsync(id);

            await _unitOfWork.CompleteAsync();
            return x;
        }

        public Task<IEnumerable<Doctor>> GetAllDoctorAsync()
        {
            var x = _doctorRepository.GetAllDoctorAsync();

            return x;
        }

        public IEnumerable<Doctor> GetAllDoctor()
        {
            var x = _doctorRepository.GetAllDoctor();

            return x;
        }



        public async Task<Doctor> UpdateDoctor(int id ,Doctor doctorToUpdateDto)
        {
            var DoctorDB = await _doctorRepository.FindDoctorByIdAsync(id);
            if( DoctorDB == null )
            {
                doctorToUpdateDto.DoctorId = id;
                await _doctorRepository.AddDoctor(doctorToUpdateDto);

            }
            else
            {
                await _doctorRepository.UpdateDoctorAsync(id ,doctorToUpdateDto);

            }
            await _unitOfWork.CompleteAsync();
            DoctorDB = await _doctorRepository.FindDoctorByIdAsync(id);

            return DoctorDB;
        }


    }
}