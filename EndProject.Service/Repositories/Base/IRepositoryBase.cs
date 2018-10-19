

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EndProject.Service.Repositories.Base
{
    public interface IRepositoryBase<TEntidade, TId>
    where TEntidade : class
    where TId : struct
    {
        IQueryable<TEntidade> ListBy(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);
        IQueryable<TEntidade> ListAndOrderBy<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);
        TEntidade GetBy(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties);
        bool Existe(Func<TEntidade, bool> where);
        IQueryable<TEntidade> list(params Expression<Func<TEntidade, object>>[] includeProperties);
        IQueryable<TEntidade> ListOrderBy<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);
        TEntidade GetById(TId id, params Expression<Func<TEntidade, object>>[] includeProperties);
        TEntidade Add(TEntidade entidade);
        TEntidade Edit(TEntidade entidade);
        void Remove(TEntidade entidade);
        IEnumerable<TEntidade> AddList(IEnumerable<TEntidade> entidades); 
    }
}
