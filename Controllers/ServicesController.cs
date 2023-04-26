using Microsoft.AspNetCore.Mvc;
using serviceApi.models;
using serviceApi.services;
using serviceApi.interfaces;
using serviceApi.interfaces.DTO;
using serviceApi.context;

namespace serviceApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ServicesService _service;

        public ServicesController(ServicesDb contex)
        {
            _service = new ServicesService(contex);
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
            var value = await _service.CreateServices(body);

            if ( value == null)
                return NotFound();
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServicesModel>> Update([FromRoute] string id, [FromBody]UpdateServiceDTO values)
        {
            var data = await _service.AuthService(id, values.Estatus, values.UserId);

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        } 
    }
}