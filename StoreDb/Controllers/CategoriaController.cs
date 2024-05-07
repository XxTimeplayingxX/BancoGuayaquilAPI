using Microsoft.AspNetCore.Mvc;
using StoreDb.BUSINESS;
using StoreDb.RESPONSE;
using StoreDb.Services.Interfaces;
using static StoreDb.BUSINESS.CategoriaBusiness;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoriaController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        BusinessLogicCategoria categoriaBusiness = new BusinessLogicCategoria();
        Response response = new Response();
        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                response = await _categoryService.GetCategory();
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

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                response = await categoriaBusiness.LlamarAMappingCategoriaByName(name);
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

        //// POST api/<CategoriaController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CategoriaController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoriaController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
