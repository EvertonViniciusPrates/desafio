using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace livraria.Models
{
    public class Cliente
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
