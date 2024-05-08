using BE_Ventas.Common.Dtos;
using BE_Ventas.Repository.Interfaces;
using BE_Ventas.Services.Interfaces;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace BE_Ventas.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _iClienteRepository;

        public ClienteServices(IClienteRepository iClienteRepository)
        {
            _iClienteRepository = iClienteRepository;
        }

        public async Task<List<ClienteDto>> ObtenerClientes()
        {            
            List<ClienteDto> _clientesDto = new();
            List<Common.Models.Cliente> _clientes = await _iClienteRepository.ObtenerClientes();
            
            _clientes.ToList().ForEach(x => _clientesDto.Add(new ClienteDto()
            {
                IdCliente = x.IdCliente,
                DNI = x.DNI,
                Email = x.Email,                
                Nombre = x.Nombre
            }));

            return await Task.Run(() => _clientesDto);
        }

        public async Task<bool> CrearCliente(ClienteDto clienteDto)
        {
            Common.Models.Cliente cliente = new()
            {
                IdCliente = clienteDto.IdCliente,
                Nombre = clienteDto.Nombre,
                DNI = clienteDto.DNI,
                Email = clienteDto.Email
            };

            ClienteValidacion validador = new();
            FluentValidation.Results.ValidationResult resultado = validador.Validate(cliente);

            if(resultado.IsValid)
            {
                return await Task.Run(() => _iClienteRepository.CrearCliente(cliente));
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ModificarCliente(ClienteDto clienteDto)
        {
            Common.Models.Cliente cliente = new()
            {
                IdCliente = clienteDto.IdCliente,
                Nombre = clienteDto.Nombre,
                DNI = clienteDto.DNI,
                Email = clienteDto.Email
            };

            ClienteValidacion validador = new();
            FluentValidation.Results.ValidationResult resultado = validador.Validate(cliente);

            if (resultado.IsValid)
            {
                return await Task.Run(() => _iClienteRepository.ModificarCliente(cliente));
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EliminarCliente(int id)
        {
            return await Task.Run( () => _iClienteRepository.EliminarCliente(id));
        }
    }
}
