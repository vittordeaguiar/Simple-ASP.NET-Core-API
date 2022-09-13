using App.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace App.Persistence.Repositories
{
    // Vai implementar a nossa classe "IRepositoryBase"
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public DbContext _dbContextEntity { get; set; }
        public DbSet<TEntity> _dbSetEntity { get; set; }
        public RepositoryBase(AppDbContext dbContext)
        {
            _dbContextEntity = dbContext;
            _dbContextEntity.ChangeTracker.AutoDetectChangesEnabled = false;
            _dbSetEntity = dbContext.Set<TEntity>();
        }
        public DbContext Context()
        {
            return _dbContextEntity;
        }
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            return _dbSetEntity.Where(where).AsNoTracking();
        }

        public void Save(TEntity obj)
        {
            if ((Guid)obj.GetType().GetProperty("Id").GetValue(obj, null) != Guid.Empty)
            {
                _dbSetEntity.Update(obj); // Se já existe, será dado um update
            }
            else
            {
                _dbSetEntity.Add(obj); // Se não existe, será adicionado
            }
        }

        public void Update(TEntity obj)
        {
            _dbSetEntity.Update(obj);
        }

        public int SaveChanges()
        {
            var written = 0;
            while (written == 0)
            {
                try
                {
                    written = _dbContextEntity.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        throw new NotSupportedException("Ocorreu um erro em: " + entry.Metadata.Name);
                    }
                }
            }
            return written;
        }
    }
}
