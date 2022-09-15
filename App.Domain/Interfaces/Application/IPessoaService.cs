using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Entities;

namespace App.Domain.Interfaces.Application
{
    public interface IPessoaService
    {
        Pessoa BuscaPorNome(string nome);
        Pessoa BuscaPorId(Guid id);
        Pessoa BuscaPorCpf(string cpf);
        List<Pessoa> ListaPessoas();
        void Salvar(Pessoa obj);
    }
}
