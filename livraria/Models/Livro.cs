using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace livraria.Models
{   
    public class Livro
    {   
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
    }
}
