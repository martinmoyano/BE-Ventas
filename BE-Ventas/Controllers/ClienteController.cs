using BE_Ventas.Common.Dtos;
using BE_Ventas.Repository.Interfaces;
using BE_Ventas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _iClienteServices;
        public ClienteController(IClienteServices iClienteServices)
        {
            _iClienteServices = iClienteServices;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {                
                List<ClienteDto> _clienteDto = await _iClienteServices.ObtenerClientes().ConfigureAwait(false);
                if(_clienteDto!=null)
                {
                    return Ok(_clienteDto);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDto clienteDto)
        {
            try
            {
                return Ok(await _iClienteServices.CrearCliente(clienteDto).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult>Put(int id, [FromBody] ClienteDto clienteDto)
        {
            try
            {
                return Ok(await _iClienteServices.ModificarCliente(clienteDto).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _iClienteServices.EliminarCliente(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
