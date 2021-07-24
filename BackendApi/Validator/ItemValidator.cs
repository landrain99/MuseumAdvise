using BackendApi.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Validator
{
    public class ItemValidator : AbstractValidator<UserModel>
    {

        public ItemValidator()
        {
            //Rule for usermodel 
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The field Name is required")
                .Length(1, 50).WithMessage("The field name need to hava a lenght between 1 and 50");
            RuleFor(x=>x.Surname)
                .NotEmpty().WithMessage("The field Surname is required")
                .Length(1, 50).WithMessage("The field Surname need to hava a lenght between 1 and 50");
            RuleFor(x=>x.Email)
                .Length(1, 50).WithMessage("The field email need to hava a lenght between 1 and 50");
            RuleFor(x=>x.Password)
                .NotEmpty().WithMessage("The field Surname is required")
                .Length(1, 50).WithMessage("The field Surname need to hava a lenght between 1 and 50");

        }
    }
}
