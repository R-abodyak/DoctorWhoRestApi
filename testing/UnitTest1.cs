using DoctorWho.DB.Resources;
using DoctorWho.DB.Validation;
using FluentValidation.Results;
using System;
using Xunit;

namespace testing
{
    public class ValidationTest
    {
        public DoctorForUpdateDto doctorForUpdateDto;
        public DoctorForUpdateDto doctorForUpdateDto2;
        public DoctorForUpdateDto doctorForUpdateDto3, doctorForUpdateDto4;
        DoctorForUpdateDtoValidator validator;
        public ValidationTest()
        {
            validator = new DoctorForUpdateDtoValidator();
            doctorForUpdateDto = new DoctorForUpdateDto() { BirthDate = new DateTime(2020 ,6 ,6) };
            doctorForUpdateDto2 = new DoctorForUpdateDto() { DoctorName = "ii" ,DoctorNumber = 654 };
            doctorForUpdateDto3 = new DoctorForUpdateDto()
            {
                DoctorName = "ii" ,
                DoctorNumber = 654 ,
                FirstEpisodeDate = new DateTime(2020 ,5 ,6) ,
                LastEpisodeDate = new DateTime(2019 ,6 ,6)
            };
            doctorForUpdateDto4 = new DoctorForUpdateDto()
            {
                DoctorName = "ii" ,
                DoctorNumber = 654 ,
                FirstEpisodeDate = new DateTime(2020 ,5 ,6) ,
                LastEpisodeDate = new DateTime(2022 ,6 ,6)
            };


        }

        [Fact]
        public void TestFluentValidationForDoctorDto_With_Required_field()
        {

            ValidationResult result = validator.Validate(doctorForUpdateDto2);

            //Assert.True(result.IsValid);
            if( !result.IsValid )
            {
                foreach( var failure in result.Errors )
                {
                    Assert.Equal("" ,"Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

        }
        [Fact]
        public void TestFluentValidationForDoctorDto_Invalid_lastEpisodeLessThanFirst()
        {

            ValidationResult result = validator.Validate(doctorForUpdateDto3);

            Assert.False(result.IsValid);

        }

    }
}
