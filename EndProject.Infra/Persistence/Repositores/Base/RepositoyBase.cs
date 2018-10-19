using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EndProject.Domain.Entities.Base;
using EndProject.Service.Repositories.Base;

namespace EndProject.Infra.Persistence.Repositores.Base
{
    public class RepositoyBase<TEntidade, TId> : IRepositoryBase<TEntidade, TId>
     where TId : struct
     where TEntidade : EntityBase
    {
        public TEntidade Add(TEntidade entidade)
        {
            return _context.Set<TEntidade>().Add(entidade);
        }

        private readonly DbContext _context;

        public RepositoyBase(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntidade> AddList(IEnumerable<TEntidade> entidades)
        {
            return _context.Set<TEntidade>().AddRange(entidades);
        }

        public TEntidade Edit(TEntidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            return entidade;
        }

        public bool Existe(Func<TEntidade, bool> where)
        {
            return _context.Set<TEntidade>().Any(where);
        }

        public TEntidade GetBy(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return list(includeProperties).FirstOrDefault(where);
        }

        public TEntidade GetById(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return list(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }
            return _context.Set<TEntidade>().Find(id);
        }

        public IQueryable<TEntidade> list(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();
            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntidade>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntidade> ListAndOrderBy<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? ListBy(where, includeProperties).OrderBy(ordem) : ListBy(where, includeProperties).OrderByDescending(ordem);
        }

        public IQueryable<TEntidade> ListBy(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return list(includeProperties).Where(where);
        }

        public IQueryable<TEntidade> ListOrderBy<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? list(includeProperties).OrderBy(ordem) : list(includeProperties).OrderByDescending(ordem);
        }

        public void Remove(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query,
            params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
