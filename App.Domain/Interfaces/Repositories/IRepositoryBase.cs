using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.Interfaces.Repositories
{
    // Criação das assinaturas dos métodos. Serão criadas 4 assinaturas
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);
        
        /*
         * Métodos de busca utilizarão o "Query"
         * Vai retornar qualquer tipo de dado que for inserido
         */
        
        void Save(TEntity obj); // Não retorna nada, somente altera o valor
        void Delete(Guid id); // Deleta
        void Update(TEntity obj); // "obj" é o apelido
        int SaveChanges(); // Só grava no banco se eu der um "SaveChanges()"
        DbContext Context();
        void Delete(object id);
    }
}
