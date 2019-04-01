using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetCoreDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private IEnderecoRepositorio _enderecoRepo;

        public EnderecoController(IEnderecoRepositorio enderecoRepo)
        {
            _enderecoRepo = enderecoRepo;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var enderecos = await _enderecoRepo.GetAllAsync();
            return Newtonsoft.Json.JsonConvert.SerializeObject(enderecos);
        }

        [HttpPost]
        public IActionResult Create(Endereco endereco)
        {
            _enderecoRepo.InsertAsync(endereco);
            return CreatedAtRoute("Endereco/Create", true);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Endereco endereco)
        {
            _enderecoRepo.UpdateAsync(endereco);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _enderecoRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}