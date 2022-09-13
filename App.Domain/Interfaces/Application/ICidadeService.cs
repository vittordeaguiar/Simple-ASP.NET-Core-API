﻿using System;
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
        Cidade BuscaPorCep(string cep); // Digitar o CEP e retornar o nome da cidade
        void Remover(Guid id); // Vamos remover a cidade pelo id
        void Salvar(Cidade obj);
        List<Cidade> ListaCidades(string cep, string nome);

    }
}
