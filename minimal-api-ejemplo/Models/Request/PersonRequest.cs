using FluentValidation;

namespace minimal_api_ejemplo.Models.Request
{
  public class PersonRequest
  {
    public required string CardNumber { get; set; }
    public required string Name { get; set; }

    public string? Telephone { get; set; }
  }
  public class CrearTramiteCommandValidator : AbstractValidator<PersonRequest>
  {
    public CrearTramiteCommandValidator()
    {
      RuleFor(e => e.CardNumber)
                 .NotEmpty().WithMessage("{PropertyName} es requerida.")
                 .NotNull().WithMessage("{PropertyName} No puede ser nulo.");
    }
  }
}
