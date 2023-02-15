using FluentValidation;

namespace Infotecs.Application.Values.Commands.CreateValue
{
    public class CreateValueCommandValidator : AbstractValidator<CreateValueCommand>
    {
        public CreateValueCommandValidator()
        {

            RuleFor(createValueCommand =>
                    createValueCommand.DateAndTime).NotEmpty().Must(BeAValidDate);
            RuleFor(createValueCommand =>
                   createValueCommand.Seсonds).GreaterThanOrEqualTo(0);
            RuleFor(createValueCommand =>
                   createValueCommand.Indicator).GreaterThanOrEqualTo(0);

        }

        private bool BeAValidDate(DateTime date)
        {
            bool result;

            DateTime badDate = new(2000, 1, 1);

            if (date >= badDate && date <= DateTime.Now)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
