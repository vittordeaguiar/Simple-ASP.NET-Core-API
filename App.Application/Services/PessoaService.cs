using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;

namespace App.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private IRepositoryBase<Pessoa> _repository { get; set; }
        public PessoaService(IRepositoryBase<Pessoa> repository)
        {
            _repository = repository;
        }
        public Pessoa BuscaPorId(Guid id)
        {
            return _repository.Query(x => x.Id == id).FirstOrDefault();
        }

        public List<Pessoa> ListaPessoas()
        {
            return _repository.Query(x => true).ToList();
        }

        public void Salvar(Pessoa obj)
        {
            if (String.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("Informe o nome");
            }
            _repository.Save(obj);
            _repository.SaveChanges();
        }

        public Pessoa BuscaPorNome(string nome)
        {
            var retornoPessoas = _repository.Query(x => x.Nome == nome).FirstOrDefault();
            return retornoPessoas;
        }

        public Pessoa BuscaPorCpf(string cpf)
        {
            return _repository.Query(x => x.Cpf == cpf).FirstOrDefault();
        }
    }
}
