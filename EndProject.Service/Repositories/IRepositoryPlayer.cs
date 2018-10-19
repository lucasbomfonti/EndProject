using System;
using System.Collections.Generic;
using EndProject.Domain.Arguments.Player;
using EndProject.Domain.Entities;
using EndProject.Service.Repositories.Base;

namespace EndProject.Service.Repositories
{
    public interface IRepositoryPlayer : IRepositoryBase<Player, Guid>
    {
        
    }
}
