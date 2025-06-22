using FluentValidation;
using SmartClinic.Core.Models;

namespace SmartClinic.Core.Validators;

public class MedicalRecordValidator : AbstractValidator<MedicalRecord>
{
    public MedicalRecordValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Medical Record ID must be greater than 0");

        RuleFor(x => x.PatientId)
            .GreaterThan(0)
            .WithMessage("Patient ID must be greater than 0");

        RuleFor(x => x.Appointments)
            .NotNull()
            .WithMessage("Appointments list cannot be null");

        RuleForEach(x => x.Appointments)
            .NotNull()
            .WithMessage("Individual appointments cannot be null");
    }
}
