using Microsoft.AspNetCore.Mvc;
using serviceApi.models;
using serviceApi.services;
using serviceApi.interfaces;
using serviceApi.interfaces.DTO;

namespace serviceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IRepository<ServicesModel> repository;
        private readonly ServicesService _service;

        public ServicesController(IRepository<ServicesModel> context)
        {
            repository = context;
            _service = new ServicesService(repository);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicesModel>>> GetServices()
        {
            IEnumerable<ServicesModel> values = await _service.FindServices();

            if (values == null) return NotFound();
            return Ok(values);
        }

        [HttpPost]
        public async Task<ActionResult<ServicesModel>> insert( InsertServiceDTO body)
        {
            Console.WriteLine(body.descripcion);
            var value = await _service.CreateServices(
                titulo: body.titulo,
                descripcion: body.descripcion,
                imagen: body.imagen,
                user: body.user
            );

            if ( value == null)
                return NotFound();
            return Ok(value);
        }
    }
}