using BE_Ventas.Common.Dtos;
using BE_Ventas.Repository;
using BE_Ventas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServices _iProductoServices;

        public ProductoController(IProductoServices iProductoServices)
        {
            _iProductoServices = iProductoServices; 
        }

        // GET: api/<ProductoController>
        /// <summary>
        /// Obtener Lista de Productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ProductoDto>  _productosDto = await _iProductoServices.ObtenerProductos().ConfigureAwait(false);
                if(_productosDto != null)
                {
                    return Ok(_productosDto);
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
                
        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoDto productoDto)
        {
            try
            {
                return Ok(await _iProductoServices.CrearProducto(productoDto).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }
                
        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductoDto productoDto)
        {
            try
            {
                return Ok(await _iProductoServices.ModificarProducto(productoDto).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);                
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _iProductoServices.BorrarProducto(id).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);                
            }
        }
    }
}
