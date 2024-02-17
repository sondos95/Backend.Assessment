using Backend.Assessment.Application.Interfaces;
using Backend.Assessment.Application.Repositories;
using Backend.Assessment.Application.Requests;
using Backend.Assessment.Domain.Entities;
using Backend.Assessment.Infrastructure.Context;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Backend.Assessment.Api.Validations
{
    public class UpdateDriverValidation : AbstractValidator<UpdateDriverViewModel>
    {
        /// <summary>
        /// Fluent Validation For Update Operation
        /// </summary>
        public UpdateDriverValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name Must has a value").MaximumLength(25).WithMessage("Exceed Maximum length");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("First Name Must has a value").MaximumLength(25).WithMessage("Exceed Maximum length");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            //RuleFor(x => x.PhoneNumber)
            //    .Matches(new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")).WithMessage("PhoneNumber not valid");
        }
       
    }
}
