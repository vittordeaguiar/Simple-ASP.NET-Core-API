using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;

namespace App.Application.Services
{
    public class CidadeService : ICidadeService
    {
        // Declarando a conexão com o banco, na entidade Cidade
        private IRepositoryBase<Cidade> _repository { get; set; }
        public CidadeService(IRepositoryBase<Cidade> repository) // Construtor
        {
            _repository = repository;
        }
        public Cidade BuscaPorCep(string cep)
        {
            if (Equals(!String.IsNullOrEmpty(cep)))
            {
                throw new Exception("Informe o CEP");
            }
            // Vai ir para o banco buscar/comparar o CEP inserido
            var retornoCidade = _repository.Query(cidade => cidade.Cep == cep).FirstOrDefault();
            return retornoCidade;
        }

        public Cidade BuscaPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o ID");
            }
            return _repository.Query(x => x.Id == id).FirstOrDefault();
        }
        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public void Salvar(Cidade obj)
        {
            if (String.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("Informa o nome da cidade");
            }
            // Somente recebe o objeto e salva
            _repository.Save(obj);
            _repository.SaveChanges();
        }

        // Espera receber uma lista de cidades
        public List<Cidade> ListaCidades(string? nome, string? cep) // Pode filtrar por CEP ou nome da cidade
        {
            return _repository.Query(x =>
            (
            (nome == null || x.Nome.Contains(nome)) && 
            (cep == null || x.Cep.Contains(cep))
            )
            ).ToList();
        }

        public void RemoverPorNome(string Nome)
        {
            var cidade = _repository.Query(x => x.Nome == Nome).FirstOrDefault();
            if (cidade != null)
            {
                _repository.Delete(cidade.Id);
            }
            else
            {
                throw new Exception("Cidade não encontrada");
            }
        }
    }
}
