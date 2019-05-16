using System;

namespace EndProject.Domain.Arguments.Platform
{
    public class AddPlatformResponse
    {
        public Guid Id { get; set; }
        public string  Nome { get; set; }
        public string Message { get; set; }
    }
}
