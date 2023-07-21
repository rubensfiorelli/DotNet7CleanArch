using Microsoft.AspNetCore.Mvc;
using System.Net;
using TravelNet.Domain.Entities.ClienteContext;
using TravelNet.Domain.Interfaces.Services;

namespace TravalNet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                Problem(detail: "Não foi possivel retornar os clientes", statusCode: 400, title: "Busca Clientes");
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException a)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, a.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                Problem(detail: "Não foi possivel retornar os clientes", statusCode: 400, title: "Busca Clientes");
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException a)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, a.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                Problem(detail: "Não foi possivel retornar os clientes", statusCode: 400, title: "Busca Clientes");
            }

            try
            {
                var seek = await _service.Post(cliente);
                if (seek != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = seek.Id })), seek);
                }
                else
                {
                    return Problem(detail: "Não foi possivel inserir cliente", statusCode: 400, title: "Inseir Cliente");
                }
            }
            catch (ArgumentException a)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, a.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                Problem(detail: "Não foi possivel retornar os clientes", statusCode: 400, title: "Busca Clientes");
            }

            try
            {
                var seek = await _service.Put(cliente);
                if (seek != null)
                {
                    return Ok(seek);
                }
                else
                {
                    return Problem(detail: "Não foi possivel inserir cliente", statusCode: 400, title: "Inseir Cliente");
                }

            }
            catch (ArgumentException a)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, a.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                Problem(detail: "Não foi possivel retornar os clientes", statusCode: 400, title: "Busca Clientes");
            }

            try
            {
                return Ok(await _service.Delete(id));

            }
            catch (ArgumentException a)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, a.Message);

            }


        }
    }
}
