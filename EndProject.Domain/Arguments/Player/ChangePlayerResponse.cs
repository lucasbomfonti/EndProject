using System;

namespace EndProject.Domain.Arguments.Player
{
    public class ChangePlayerResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Message { get; set; }
        public static explicit operator ChangePlayerResponse(Entities.Player entidade)
        {
            return new ChangePlayerResponse()
            {
                Email = entidade.Email.Address,
                Id = entidade.Id,
                FirstName = entidade.Name.FirstName,
                LastName = entidade.Name.LastName,
                Message = "Success"
            };
        }
    }
}
