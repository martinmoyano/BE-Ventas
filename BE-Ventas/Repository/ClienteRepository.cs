using BE_Ventas.Repository.Interfaces;

namespace BE_Ventas.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AplicationDbContext _context;
        
        public ClienteRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Common.Models.Cliente>> ObtenerClientes()
        {
            var lista = _context.Cliente.Select(x => x);
            List<Common.Models.Cliente> _clientes = new();

            lista.ToList().ForEach(x => _clientes.Add(new Common.Models.Cliente()
            {
                IdCliente = x.IdCliente,
                Nombre = x.Nombre,
                DNI = x.DNI,
                Email = x.Email
            }));

            return await Task.Run(() => _clientes);
        }

        public async Task<bool> CrearCliente(Common.Models.Cliente cliente)
        {
            Repository.Entities.Cliente clienteBD = new()
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                DNI = cliente.DNI,
                Email = cliente.Email
            };

            _context.Cliente.Add(clienteBD);
            _context.SaveChanges();

            return await Task.Run(() => true);
        }

        public async Task<bool> ModificarCliente(Common.Models.Cliente cliente)
        {
            Repository.Entities.Cliente clienteBD = new()
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                DNI = cliente.DNI,
                Email = cliente.Email
            };

            _context.Cliente.Update(clienteBD);
            _context.SaveChanges();

            return await Task.Run(() => true);
        }

        public async Task<bool> EliminarCliente(int id)
        {
            var clienteId = _context.Cliente.Where(cliente => cliente.IdCliente == id);

            foreach (var item in clienteId)
            {
                _context.Cliente.Remove(item);
            }
            _context.SaveChanges();

            return await Task.Run(() => true);
        }
    }
}
