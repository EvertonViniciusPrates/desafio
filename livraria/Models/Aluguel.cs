using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace livraria.Models
{
    public class Aluguel
    {
        public Guid Codigo { get; set; }
        public DateTime DataDeRetirada { get; set; }
        public DateTime DataDeEntrega { get; set; }
        public Boolean Status { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Guid LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}
