using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetCoreDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private IDepartamentoRepositorio _departamentoRepo;

        public DepartamentoController(IDepartamentoRepositorio departamentoRepo)
        {
            _departamentoRepo = departamentoRepo;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var departamentos = await _departamentoRepo.GetAllAsync();
            return Newtonsoft.Json.JsonConvert.SerializeObject(departamentos);
        }

        [HttpPost]
        public IActionResult Create(Departamento departamento)
        {
            _departamentoRepo.InsertAsync(departamento);
            return CreatedAtRoute("Departamento/Create", true);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Departamento departamento)
        {
            _departamentoRepo.UpdateAsync(departamento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _departamentoRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}