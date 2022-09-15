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
            // Vai ir para o banco buscar/comparar o CEP inserido
            var retornoCidade = _repository.Query(cidade => cidade.Cep == cep).FirstOrDefault();
            return retornoCidade;
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Cidade obj)
        {
            throw new NotImplementedException();
        }

        public List<Cidade> ListaCidades(string cep, string nome)
        {
            throw new NotImplementedException();
        }

        //public Cidade BuscaPorCep(Guid id)
        //{
        //    var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
        //    return obj;
        //}

        //public List<Cidade> ListaCidades()
        //{
        //    return _repository.Query(x => 1 == 1).ToList();
        //}
    }
}
