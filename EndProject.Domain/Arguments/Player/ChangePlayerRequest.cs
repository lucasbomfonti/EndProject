using System;

namespace EndProject.Domain.Arguments.Player
{
    public class ChangePlayerRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
