using BE_Ventas.Common.Dtos;

namespace BE_Ventas.Services.Interfaces
{
    public interface IClienteServices
    {
        public Task<List<ClienteDto>> ObtenerClientes();
        public Task<bool> CrearCliente(ClienteDto clienteDto);
        public Task<bool> ModificarCliente(ClienteDto clienteDto);
        public Task<bool> EliminarCliente(int id);
    }
}
