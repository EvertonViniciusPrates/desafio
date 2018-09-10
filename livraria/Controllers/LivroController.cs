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
    public class LivroController : Controller
    {
        private readonly LivrariaContexto _contexto;

        public LivroController(LivrariaContexto _contexto)
        {
            this._contexto = _contexto;
        }

        [HttpGet]
        public IEnumerable<Livro> GetAll()
        {
            var livros = _contexto.Livros.ToList();

            return _contexto.Livros.ToList();
        }

        [HttpGet("{codigo}/livro")]
        public IActionResult BuscarPorId(Guid codigo)
        {
            var livro = _contexto.Livros.FirstOrDefault(x => x.Codigo == codigo);

            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Livro livro)
        {
            if (livro == null)
                return BadRequest();

            else
            {
                livro.Codigo = Guid.NewGuid();
                _contexto.Livros.Add(livro);
                _contexto.SaveChanges();
                return Ok();
            }
        }

        [HttpPut("{codigo}/editalivro")]
        public IActionResult Update([FromBody]Livro livro, Guid codigo)
        {
            Livro _livro = _contexto.Livros.FirstOrDefault(x => x.Codigo == codigo);
            if (_livro == null)
                return BadRequest();

            if (codigo != _livro.Codigo)
            {
                return BadRequest();
            }
            else
            {
                _livro.Autor = livro.Autor;
                _livro.Descricao = livro.Descricao;
                _livro.Nome = livro.Nome;
                _contexto.Update(_livro);
                _contexto.SaveChanges();

                return Ok();
            }
        }
        [HttpDelete("{codigo}/deletalivro")]
        public IActionResult Delete(Guid codigo)
        {
            Livro _livro = _contexto.Livros.FirstOrDefault(x => x.Codigo == codigo);
            if (codigo != _livro.Codigo)
            {
                return BadRequest();
            }
            else
            {
                _contexto.Livros.Remove(_livro);
                _contexto.SaveChanges();
                return Ok();
            }
        }
    }
}