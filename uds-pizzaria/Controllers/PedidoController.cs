using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.ServiceInterface;

namespace uds_pizzaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;

        public PedidoController(IPedidoService service)
        {
            _service = service;
        }
        // POST: api/Pedido
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] PedidoDto value)
        {
            return Ok(_service.CadastrarPedido(value));
        }
    }
}
