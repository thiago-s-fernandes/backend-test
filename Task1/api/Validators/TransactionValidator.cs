using FluentValidation;
using api.Models;

namespace api.Validators
{
  public class TransactionValidator : AbstractValidator<Transaction>
  {
    public TransactionValidator()
    {
      RuleFor(t => t.AccountID)
          .NotEmpty().WithMessage("Account ID is required.");

      RuleFor(t => t.TransactionID)
          .NotEmpty().WithMessage("Transaction ID is required.");

      RuleFor(t => t.TransactionAmount)
          .NotEmpty().WithMessage("Transaction amount is required.")
          .GreaterThan(0).WithMessage("Transaction amount must be greater than 0.");

      RuleFor(t => t.TransactionCurrencyCode)
          .NotEmpty().WithMessage("Currency code is required.")
          .Length(3).WithMessage("Currency code must be 3 characters.");

      RuleFor(t => t.LocalHour)
          .InclusiveBetween(0, 23).WithMessage("Local hour must be between 0 and 23.");

      RuleFor(t => t.TransactionScenario)
          .NotEmpty().WithMessage("Transaction scenario is required.");

      RuleFor(t => t.TransactionType)
          .NotEmpty().WithMessage("Transaction type is required.");

      RuleFor(t => t.TransactionIPaddress)
          .NotEmpty().WithMessage("IP address is required.")
          .Matches(@"^(\d{1,3}\.){3}\d{1,3}$").WithMessage("Invalid IP address format.");

      RuleFor(t => t.IpCountry)
          .NotEmpty().WithMessage("IP country is required.");

      RuleFor(t => t.DigitalItemCount)
          .GreaterThanOrEqualTo(0).WithMessage("Digital item count must be non-negative.");

      RuleFor(t => t.PhysicalItemCount)
          .GreaterThanOrEqualTo(0).WithMessage("Physical item count must be non-negative.");

      RuleFor(t => t.TransactionDateTime)
          .NotEmpty().WithMessage("Transaction date time is required.")
          .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Transaction date time cannot be in the future.");
    }
  }
}
