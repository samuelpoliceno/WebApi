using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoP.WebApi.Model;

namespace ProjetoP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        public readonly DataContext _context;

        public CidadeController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cidade>> GetAllCitys(){
            try{
                var result =  _context.Cidade.ToList();
                return result;
            }
            catch(System.Exception){
                var status500 = StatusCodes.Status500InternalServerError;
                var messageError = "Erro no Banco de Dados";
                return this.StatusCode(status500, messageError);
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Cidade> GetCityById(int id)
        {
            var result = _context.Cidade.FirstOrDefault((p) => p.Id == id);
            if(result == null){
                var status404 = StatusCodes.Status404NotFound;
                var messageError = "Nao foi encontrada a cidade com o id " + id;
                return this.StatusCode(status404, messageError);
            }
            return Ok(result);
        }

    }
}