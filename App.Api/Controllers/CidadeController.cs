using App.Domain.DTO;
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
        [HttpGet("BuscaPorCep")] // Aqui irá retornar um Json
        public JsonResult BuscaPorCep(string cep)
        {
            try
            {
                var minhaCidade = _service.BuscaPorCep(cep);
                return Json(RetornoApi.Sucesso(minhaCidade));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("ListaCidades")]
        public JsonResult ListaCidades(string? nome, string? cep)
        {
            try
            {
                var obj = _service.ListaCidades(nome, cep);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPost("Salvar")]
        public JsonResult Salvar([FromBody] Cidade obj)
        {
            try
            {
                _service.Salvar(obj); // Salvar
                return Json(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
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
