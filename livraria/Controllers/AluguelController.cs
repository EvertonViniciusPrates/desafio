using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livraria.Models;
using livraria.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : Controller
    {
        private readonly LivrariaContexto _contexto;

        public AluguelController(LivrariaContexto _contexto)
        {
            this._contexto = _contexto;
        }

        [HttpGet]
        public IEnumerable<Aluguel> GetAll()
        {
            var alugueis = _contexto.Alugueis.Include(x => x.Livro).ToList();

            return _contexto.Alugueis.ToList();
        }

        [HttpGet("{codigo}/aluguel")]
        public IActionResult BuscarPorId(Guid codigo)
        {
            var aluguel = _contexto.Alugueis.Include(x => x.Livro).FirstOrDefault(x => x.Codigo == codigo);

            if (aluguel == null)
            {
                return NotFound();
            }
            return Ok(aluguel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Aluguel aluguel)
        {
            if (aluguel == null)
                return BadRequest();

            else
            {
                aluguel.Codigo = Guid.NewGuid();
                _contexto.Alugueis.Add(aluguel);
                _contexto.SaveChanges();
                return Ok();
            }
        }

        [HttpPut("{codigo}/editaaluguel")]
        public IActionResult Update([FromBody]Aluguel aluguel, Guid codigo)
        {
            Aluguel _aluguel = _contexto.Alugueis.FirstOrDefault(x => x.Codigo == codigo);
            if (_aluguel == null)
                return BadRequest();

            if (codigo != _aluguel.Codigo)
            {
                return BadRequest();
            }
            else
            {
                _aluguel.ClienteId = aluguel.ClienteId;
                _aluguel.DataDeEntrega = aluguel.DataDeEntrega;
                _aluguel.DataDeRetirada = aluguel.DataDeRetirada;
                _aluguel.LivroId = aluguel.LivroId;
                _aluguel.Status = aluguel.Status;
                _contexto.Update(_aluguel);
                _contexto.SaveChanges();

                return Ok();
            }
        }
        [HttpDelete("{codigo}/deletaaluguel")]
        public IActionResult Delete(Guid codigo)
        {
            Aluguel _aluguel = _contexto.Alugueis.FirstOrDefault(x => x.Codigo == codigo);
            if (codigo != _aluguel.Codigo)
            {
                return BadRequest();
            }
            else
            {
                _contexto.Alugueis.Remove(_aluguel);
                _contexto.SaveChanges();
                return Ok();
            }
        }

    }
}