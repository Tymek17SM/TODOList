using Aplication.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validators
{
    public class UpdateToDoTaskDtoValidator : AbstractValidator<UpdateToDoTaskDto>
    {
        public UpdateToDoTaskDtoValidator()
        {
            #region Title
            RuleFor(x => x.Title).NotEmpty().WithMessage("Task can not have an empty title");
            RuleFor(x => x.Title).Length(5, 100).WithMessage("The title must be between 5 and 100 characters long");
            #endregion

            #region Description
            RuleFor(x => x.Description).NotEmpty().WithMessage("Task can not have an empty description");
            RuleFor(x => x.Description).Length(5, 1000).WithMessage("The description must be between 5 and 1000 characters long");
            #endregion
        }
    }
}
