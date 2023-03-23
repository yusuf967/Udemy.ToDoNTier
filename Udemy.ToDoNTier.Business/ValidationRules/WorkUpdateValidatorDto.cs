using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Dtos.WorkDtos;

namespace Udemy.ToDoNTier.Business.ValidationRules
{
    public class WorkUpdateValidatorDto:AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateValidatorDto()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Required").InclusiveBetween(1, int.MaxValue);
            RuleFor(x => x.Defination).NotEmpty().WithMessage("Defination is Required");
        }
    }
}
