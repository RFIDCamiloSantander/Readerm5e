using FluentValidation;
using Readerm5e.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readerm5e.Validators
{
    internal class ElementValidator : AbstractValidator<Element>
    {
        public ElementValidator()
        {
            //RuleFor(e => e.EPC).MinimumLength(4).MaximumLength(24).NotEmpty().NotNull();
            RuleFor(e => e.EPC).Length(4, 24).NotEmpty().NotNull();
            RuleFor(e => e.Name).NotNull().NotEmpty().Length(2, 30).WithName("Nombre");
            RuleFor(e => e.Description).MaximumLength(100);
            RuleFor(e => e.CreationDate).NotNull().NotEmpty();
        }
    }
}