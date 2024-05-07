using Microsoft.AspNetCore.Mvc;
using StoreDb.BUSINESS;
using StoreDb.Repositories.Interfaces;
using StoreDb.RESPONSE;
using StoreDb.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreDb.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        Response response = new Response();
        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
                try
                {
                    response = await _productoService.GetProductos();
                }
                catch (Exception ex)
                {
                    response = new Response()
                    {
                        code = ResponseType.Error,
                        message = ex.Message,
                        data = ex.InnerException
                    };
                }
                return Ok(response);
            
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string name)
        {
            
            try
            {
                response = await _productoService.GetProductoByName(name);
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }
            return Ok(response);
        }

        // POST api/<ProductoController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProductoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
