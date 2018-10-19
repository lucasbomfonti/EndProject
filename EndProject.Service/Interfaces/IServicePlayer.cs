using System;
using System.Collections.Generic;
using EndProject.Domain.Arguments.Base;
using EndProject.Domain.Arguments.Player;
using EndProject.Service.Interfaces.Base;

namespace EndProject.Service.Interfaces
{
    public interface IServicePlayer : IServiceBase
    {
        AuthenticatePlayerResponse AuthenticatePlayer(AuthenticatePlayerRequest request);
        AddPlayerResponse AddPlayer(AddPlayerRequest request);
        ChangePlayerResponse ChangePlayer(ChangePlayerRequest request);
        IEnumerable<PlayerResponse> PlayerList();
        ResponseBase DeletePlayer(Guid id);


    }
}
