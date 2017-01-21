using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.reposiories
{
    public class Repository<TEntity> : IRepository<TEntity>
         where TEntity : class

    {
        private DbContext _dbcontext { get { return _dbProvider.GetDbContext(); } }

        private DbSet<TEntity> Table { get { return _dbcontext.Set<TEntity>(); } }

        private readonly IDbContextProvider _dbProvider;


        public Repository(IDbContextProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            if (propertySelectors.IsNullOrEmpty())
            {
                return GetAll();
            }

            var query = GetAll();

            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }

            return query;
        }

        public List<TEntity> GetAllList()
        {
            return Table.ToList();
        }

        public Task<List<TEntity>> GetAllListAsync()
        {
            return Table.ToListAsync();
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).ToListAsync();
        }


        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.FirstOrDefaultAsync(predicate);
        }

        public TEntity Insert(TEntity entity)
        {
            return Table.Add(entity).Entity;
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            return Task.FromResult(Insert(entity));
        }

        public TEntity Update(TEntity entity)
        {
            return Table.Update(entity).Entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult(0);
        }


        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll().Where(predicate).ToList())
            {
                Delete(entity);
            }
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Delete(predicate);
            return Task.FromResult(0);
        }

        public int Count()
        {
            return Table.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Count(predicate);
        }

        public Task<int> CountAsync()
        {
            return Task.FromResult(Count());
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Count(predicate));
        }


        public long LongCount()
        {
            return Table.LongCount();
        }

        public Task<long> LongCountAsync()
        {
            return Task.FromResult(LongCount());

        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.LongCount(predicate);
        }

        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(LongCount(predicate));
        }

        public void Commit()
        {
            _dbcontext.SaveChanges();
        }

        public List<TEntity> GetAllByPaged(int page, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {

            return Table.Where(predicate).OrderBy(s => s.ToString()).Skip((page - 1)*pageSize).Take(pageSize).ToList();
        }

        public List<TEntity> GetAllByPaged(int page, int pageSize)
        {
            return Table.OrderBy(s=>s.ToString()).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}


