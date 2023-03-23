using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Dtos.WorkDtos;

namespace Udemy.ToDoNTier.Business.ValidationRules
{
    public class WorkCreateValidatorDto:AbstractValidator<WorkCreateDto>
    {
        public WorkCreateValidatorDto()
        {
            RuleFor(x => x.Defination).NotEmpty().WithMessage("Defination is Required");
        }
    }
}
