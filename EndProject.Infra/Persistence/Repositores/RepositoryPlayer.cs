using System;
using EndProject.Domain.Entities;
using EndProject.Infra.Persistence.Repositores.Base;
using EndProject.Service.Repositories;

namespace EndProject.Infra.Persistence.Repositores
{
    public class RepositoryPlayer : RepositoyBase<Player, Guid>, IRepositoryPlayer
    {
        protected readonly EndProjectContext EndProjectContext;

        public RepositoryPlayer(EndProjectContext endProjectContext) : base(endProjectContext)
        {
            EndProjectContext = endProjectContext;
        }

    }
}
