using FluentValidation;
using InsurancePolicy.Domain;

namespace InsurancePolicyAPI.Validations
{
    public class PolicyValidator : AbstractValidator<Policy>
    {
        public PolicyValidator()
        {
            // Validate that the PolicyNumber is not empty and matches the format of XX123456
            RuleFor(x => x.PolicyNumber)
                .NotEmpty().WithMessage("Policy number is required.")
                .Matches(@"^[A-Z]{2}\d{6}$").WithMessage("Policy number must be in the format like  XX123456.");
        }
    }
}
