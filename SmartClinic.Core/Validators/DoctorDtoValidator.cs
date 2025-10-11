using FluentValidation;
using SmartClinic.Core.DTOs;

namespace SmartClinic.Core.Validators;

public class DoctorDtoValidator : AbstractValidator<DoctorDto>
{
    public DoctorDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Doctor ID must be greater than 0");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Doctor name cannot be empty")
            .MaximumLength(100)
            .WithMessage("Doctor name cannot exceed 100 characters");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Doctor name cannot be empty")
            .MaximumLength(100)
            .WithMessage("Doctor name cannot exceed 100 characters");

        RuleFor(x => x.Specialty)
            .NotEmpty()
            .WithMessage("Specialization cannot be empty")
            .MaximumLength(100)
            .WithMessage("Specialization cannot exceed 100 characters");
    }
}