using Backend.Assessment.Application.Requests;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Backend.Assessment.Api.Validations
{
    public class CreateDriverValidation : AbstractValidator<CreateDriverViewModel>
    {
        /// <summary>
        /// Fluent Validaion for Create operation
        /// </summary>
        public CreateDriverValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name Must has a value").MaximumLength(25).WithMessage("Exceed Maximum length");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("First Name Must has a value").MaximumLength(25).WithMessage("Exceed Maximum length");
            RuleFor(x=>x.Email).NotEmpty().EmailAddress();
            //RuleFor(x=>x.PhoneNumber)
            //    .Matches(new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")).WithMessage("PhoneNumber not valid");

        }
    }
}
