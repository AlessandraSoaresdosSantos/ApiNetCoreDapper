using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCoreDapper 
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int FuncionarioId { get; set; }
    }
}
