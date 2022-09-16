using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Entities;

namespace App.Domain.Interfaces.Application
{
    // Assinatura dos métodos
    public interface ICidadeService
    {
        Cidade BuscaPorId(Guid id);
        Cidade BuscaPorCep(string cep); // Digitar o CEP e retornar o nome da cidade
        void RemoverPorNome(string Nome); // Vamos remover a cidade pelo nome
        void Salvar(Cidade obj);
        List<Cidade> ListaCidades(string? nome, string? cep);
    }
}