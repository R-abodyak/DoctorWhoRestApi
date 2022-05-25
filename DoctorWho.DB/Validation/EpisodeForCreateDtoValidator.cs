using System;
using System.Collections.Generic;
using System.Text;
using DoctorWho.DB.Resources;
using FluentValidation;

namespace DoctorWho.DB.Validation
{
    public class EpisodeForCreateDtoValidator:AbstractValidator<EpisodeForCreateDto>
    {
        public EpisodeForCreateDtoValidator()
        {
            RuleFor(e => e.AuthorId).NotEmpty();
            RuleFor(e => e.DoctorId).NotEmpty();
            RuleFor(e => e.SeriesNumber.ToString())
                   .Must(e => e.Length == 10);
            RuleFor(e => e.EpisodeNumber).GreaterThan(0);
        }
    }
}
