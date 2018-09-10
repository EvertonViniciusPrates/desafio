using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livraria.Models;
using livraria.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly LivrariaContexto _contexto;

        public ClienteController(LivrariaContexto _contexto)
        {
            this._contexto = _contexto;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            var clientes = _contexto.Clientes.ToList();

            return _contexto.Clientes.ToList();
        }

        [HttpGet("{codigo}/cliente")]
        public IActionResult BuscarPorId(Guid codigo)
        {
            var cliente = _contexto.Clientes.FirstOrDefault(x => x.Codigo == codigo);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            else
            {
                cliente.Codigo = Guid.NewGuid();
                _contexto.Clientes.Add(cliente);
                _contexto.SaveChanges();
                return Ok();
            }
        }

        [HttpPut("{codigo}/editacliente")]
        public IActionResult Update([FromBody]Cliente cliente, Guid codigo)
        {
            Cliente _cliente = _contexto.Clientes.FirstOrDefault(x => x.Codigo == codigo);
            if (_cliente == null)
                return BadRequest();

            if (codigo != _cliente.Codigo)
            {
                return BadRequest();
            }
            else
            {
                _cliente.Cpf = cliente.Cpf;
                _cliente.Nome = cliente.Nome;
                _cliente.DataDeNascimento = cliente.DataDeNascimento;
                _contexto.Update(_cliente);
                _contexto.SaveChanges();

                return Ok();
            }
        }
        [HttpDelete("{codigo}/deletacliente")]
        public IActionResult Delete(Guid codigo)
        {
            Cliente _cliente = _contexto.Clientes.FirstOrDefault(x => x.Codigo == codigo);
            if (codigo != _cliente.Codigo)
            {
                return BadRequest();
            }
            else
            {
                _contexto.Clientes.Remove(_cliente);
                _contexto.SaveChanges();
                return Ok();
            }
        }
    }
}