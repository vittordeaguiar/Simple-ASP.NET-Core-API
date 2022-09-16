using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : Controller
    {
        private IPessoaService _service;
        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet("ListaPessoas")]
        public JsonResult ListaPessoas()
        {
            try
            {
                var lista = _service.ListaPessoas();
                return Json(RetornoApi.Sucesso(lista));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("BuscaPorId")]
        public JsonResult BuscaPorId(Guid id)
        {
            try
            {
                var busca = _service.BuscaPorId(id);
                return Json(RetornoApi.Sucesso(busca));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("BuscaPorNome")]
        public JsonResult BuscaPorNome(string? nome)
        {
            try
            {
                var pessoa = _service.BuscaPorNome(nome);
                return Json(RetornoApi.Sucesso(pessoa));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
        [HttpGet("BuscaPorCpf")]
        public JsonResult BuscaPorCpf(string cpf)
        {
            try
            {
                var buscaCpf = Json(_service.BuscaPorCpf(cpf));
                return Json(RetornoApi.Sucesso(buscaCpf));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPost("Salvar")]
        public JsonResult Salvar(string nome, int peso, string cpf, bool ativo)
        {
            try
            {
                var obj = new Pessoa
                {
                    Nome = nome,
                    //DataNascimento = dataNascimento,
                    Peso = peso,
                    Cpf = cpf,
                    Ativo = ativo
                };
                _service.Salvar(obj);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpDelete("RemoverPessoaPeloNome")]
        public JsonResult RemoverPorNome(string nome)
        {
            try
            {
                _service.RemoverPorNome(nome);
                return Json(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
