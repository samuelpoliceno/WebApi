using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoP.WebApi.Model;

namespace ProjetoP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        public readonly DataContext _context;

        public VeiculoController (DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVeiculos()
        {
            try{
                var result = await _context.Veiculo.ToListAsync();
                return Ok(result);
            }
            catch(System.Exception){
                var status500 = StatusCodes.Status500InternalServerError;
                var messageError = "Erro no Banco de Dados";
                return this.StatusCode(status500, messageError);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVeiculoById(int id)
        {
            var veiculo = await _context.Veiculo.FirstOrDefaultAsync((p) => p.Id == id);
            if(veiculo == null){
                var status404 = StatusCodes.Status404NotFound;
                var messageError = "Nao foi encontrado um veiculo com o id " + id;
                return this.StatusCode(status404, messageError);
            }
            return Ok(veiculo);
        }

        [HttpPost]
        public void Post([FromBody] string value){

        }

        [HttpPut("id")]
        public void Put(string value){

        }



    }
}