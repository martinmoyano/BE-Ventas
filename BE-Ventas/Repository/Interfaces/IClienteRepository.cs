namespace BE_Ventas.Repository.Interfaces
{
    public interface IClienteRepository
    {
        public Task<List<Common.Models.Cliente>> ObtenerClientes();
        public Task<bool> CrearCliente(Common.Models.Cliente cliente);
        public Task<bool> ModificarCliente(Common.Models.Cliente cliente);
        public Task<bool> EliminarCliente(int id);
    }
}
