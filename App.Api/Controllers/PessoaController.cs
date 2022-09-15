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
            return Json(_service.ListaPessoas());
        }

        [HttpGet("BuscaPorId")]
        public JsonResult BuscaPorId(Guid id)
        {
            return Json(_service.BuscaPorId(id));
        }

        [HttpGet("BuscaPorNome")]
        public JsonResult BuscaPorNome(string? nome)
        {
            var pessoa = _service.BuscaPorNome(nome);
            return Json(pessoa); // Pega "minhaCidade" e transforma em Json
        }
        [HttpGet("BuscaPorCpf")]
        public JsonResult BuscaPorCpf(string cpf)
        {
            return Json(_service.BuscaPorCpf(cpf));
        }

        [HttpPost("Salvar")]
        public JsonResult Salvar(string nome, int peso, string cpf, bool ativo)
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
            return Json(true);
        }
    }
}
