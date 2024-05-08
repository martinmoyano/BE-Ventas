using BE_Ventas.Common.Models;
using FluentValidation;

namespace BE_Ventas.Services
{
    public class ClienteValidacion : AbstractValidator<Cliente>
    {
        public ClienteValidacion()
        {
            RuleFor(cliente => cliente.DNI).InclusiveBetween(1111111, 99999999).WithMessage("Ingrese dni válido");            
            RuleFor(cliente => cliente.Email).EmailAddress().WithMessage("Ingrese email válido");
        }
    }
}
