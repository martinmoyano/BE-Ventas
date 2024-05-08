using BE_Ventas.Common.Dtos;
using BE_Ventas.Services;
using BE_Ventas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaServices _iVentaServices;

        public VentaController(IVentaServices iVentaServices)
        {
            _iVentaServices = iVentaServices; 
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<VentaDto> _ventasDto = await _iVentaServices.ObtenerVentas().ConfigureAwait(false);
                if(_ventasDto != null)
                {
                    return Ok(_ventasDto);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VentaCrearDto ventaDto)
        {
            try
            {
                return Ok(await _iVentaServices.CrearVenta(ventaDto).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // PUT api/<VentaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
