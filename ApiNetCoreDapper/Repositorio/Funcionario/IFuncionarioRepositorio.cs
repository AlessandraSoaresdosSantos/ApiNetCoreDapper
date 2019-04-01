using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ApiNetCoreDapper 
{
    public interface IFuncionarioRepositorio : IGenericRepository<Funcionario> { }

}
