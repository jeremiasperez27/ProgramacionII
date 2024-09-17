using Articulo_WebApi.Entities;
using Articulo_WebApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace ProduccionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private IArticuloServices servicio;

        public ArticuloController()
        {
            servicio = new ArticuloServices();
        }

        
        [HttpGet("articulos")]
        public IActionResult Get()
        {
            return Ok(servicio.ConsultarArticulos());
        }
       
        
        [HttpPost]
        public IActionResult Post([FromBody] Articulo articulo)
        {
            try { 
                if(articulo == null)
                {
                    return BadRequest("Se esperaba un articulo");
                }
                if (servicio.RegistrarArticulo(articulo))
                    return Ok("Articulo registrado con éxito!");
                else
                    return StatusCode(500, "No se pudo registrar el articulo");
            }
            catch (Exception )
            {
                return StatusCode(500, "Error interno, intente nuevamente!");
            }
        }
    }
}
