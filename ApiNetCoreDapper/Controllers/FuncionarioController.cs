using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetCoreDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepositorio _funcionarioRepo;

        public FuncionarioController(IFuncionarioRepositorio funcionarioRepo)
        {
            _funcionarioRepo = funcionarioRepo;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var funcionarios = await _funcionarioRepo.GetAllAsync();
            return Newtonsoft.Json.JsonConvert.SerializeObject(funcionarios);
        }

        [HttpPost]
        public IActionResult Create(Funcionario funcionario)
        {
            _funcionarioRepo.InsertAsync(funcionario);
            return CreatedAtRoute("Funcionario/Create", true);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Funcionario funcionario)
        {
            _funcionarioRepo.UpdateAsync(funcionario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _funcionarioRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}