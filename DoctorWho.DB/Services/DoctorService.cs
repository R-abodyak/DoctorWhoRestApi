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

        public void DeleteDoctor(int id)
        {
            _doctorRepository.DeleteDoctor(id);
            _unitOfWork.CompleteAsync();
        }

        public Task<IEnumerable<Doctor>> GetAllDoctorAsync()
        {
            var x = _doctorRepository.GetAllDoctorAsync();
            _unitOfWork.CompleteAsync();
            return x;
        }

        public IEnumerable<Doctor> GetAllDoctor()
        {
            var x = _doctorRepository.GetAllDoctor();
            _unitOfWork.CompleteAsync();
            return x;
        }

        public Task<Doctor> GetDoctor(int id)
        {
            var x = _doctorRepository.FindDoctorByIdAsync(id);
            _unitOfWork.CompleteAsync();
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
                await _doctorRepository.UpdateDoctor(id ,doctorToUpdateDto);

            }
            await _unitOfWork.CompleteAsync();
            DoctorDB = await _doctorRepository.FindDoctorByIdAsync(id);

            return DoctorDB;
        }
    }
}