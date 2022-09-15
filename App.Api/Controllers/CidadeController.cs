using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")] // Criando rota para achar controller
    public class CidadeController : Controller
    {
        private ICidadeService _service;
        public CidadeController(ICidadeService service)
        {
            _service = service;
        }
        [HttpGet("BuscaPorCep")]
        // Aqui irá retornar um Json
        public JsonResult BuscaPorCep(string cep)
        {
            var minhaCidade = _service.BuscaPorCep(cep);
            return Json(minhaCidade); // Pega "minhaCidade" e transforma em Json
        }

        [HttpGet("ListaCidades")]
        public JsonResult ListaCidades(string? nome, string? cep)
        {
            return Json(_service.ListaCidades(nome, cep));
        }

        [HttpPost("Salvar")]
        public JsonResult Salvar(string cep, string nome, string estado)
        {
            // Montando um objeto de Cidade
            var objCidade = new Cidade // Pega as entradas do usuário e transforma e cria Cidade
            {
                Cep = cep,
                Estado = estado,
                Nome = nome
            };
            _service.Salvar(objCidade); // Salvar
            return Json(true);
        }
        [HttpDelete("RemoverCidadePeloId")]
        public JsonResult Remover(Guid id)
        {
            try
            {
                _service.Remover(id);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
        [HttpDelete("RemoverCidadePeloNome")]
        public JsonResult RemoverPorNome(string Nome)
        {
            try
            {
                _service.RemoverPorNome(Nome);
                return Json(true);
            }
            catch 
            { 
                return Json(false);
            }
        }
    }
}
