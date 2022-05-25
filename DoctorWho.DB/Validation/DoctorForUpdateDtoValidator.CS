using System;
using System.Collections.Generic;
using System.Text;

using DoctorWho.DB.Resources;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Linq;

namespace DoctorWho.DB.Validation
{

    public class DoctorForUpdateDtoValidator:AbstractValidator<DoctorForUpdateDto>
    {
        private static DoctorWhoCoreDbContext context;
        public readonly DoctorWhoCoreDbContext _context;
        public DoctorForUpdateDtoValidator() : this(context)
        {
            RuleFor(d => d.DoctorName).NotNull();
            RuleFor(d => d.DoctorNumber).NotNull();
            RuleFor(c => c.LastEpisodeDate).Equal(default(DateTime)).
                When(c => c.FirstEpisodeDate == default(DateTime));
            RuleFor(x => x.LastEpisodeDate).
                GreaterThan(u => u.FirstEpisodeDate).
                When(c => c.FirstEpisodeDate != default(DateTime));
            RuleFor(x => x.DoctorNumber).Must(IsUniqueDoctorNumber).WithMessage("Doctor number already exists");


        }
        private DoctorForUpdateDtoValidator(DoctorWhoCoreDbContext context)
        {
            _context = context;

        }



        private bool IsUniqueDoctorNumber(int? number)
        {
            var result = _context.Doctors.Where(x => x.DoctorNumber == number).SingleOrDefault();
            if( result == null ) return true;
            return false;

        }
    }
}
