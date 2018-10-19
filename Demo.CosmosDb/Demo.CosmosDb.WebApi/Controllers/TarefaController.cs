using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.CosmosDb.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.CosmosDb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private TarefaContexto _contexto;

        public TarefaController(TarefaContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult ListTarefas()
        {
            return new ObjectResult(_contexto.ListarTarefas<Tarefa>());
        }

        [HttpGet("{id}")]
        public IActionResult GetTarefa(string id)
        {
            Tarefa tarefa = _contexto.ObterIarefa<Tarefa>(id);

            if (tarefa != null)
                return new ObjectResult(tarefa);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult InsertTarefa(Tarefa tarefa)
        {
            _contexto.AdicionarTarefa(tarefa);
            return Ok();
        }
    }
}