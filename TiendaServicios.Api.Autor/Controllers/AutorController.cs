using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autor.Application;
using TiendaServicios.Api.Autor.Models;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;
       

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
   
        }

        [HttpPost]

        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> GetAutores()
        {
            return await _mediator.Send(new Consulta.ListaAutor());
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<AutorDTO>> GetAutor(string guid)
        {
            return await _mediator.Send(new ConsultaFiltro.AutorUnico{ AutorGuid = guid });
        }

      
    }
}
