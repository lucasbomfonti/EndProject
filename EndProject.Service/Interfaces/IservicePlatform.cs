using System;
using EndProject.Domain.Arguments.Platform;
using EndProject.Domain.Arguments.Player;
using EndProject.Domain.ValueObjects;

namespace EndProject.Service.Interfaces
{
    public  interface IServicePlatform
    {
        AddPlatformResponse AddPlatform(AddPlatformRequest request);

    }
}
