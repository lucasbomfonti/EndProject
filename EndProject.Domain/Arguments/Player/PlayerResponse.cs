using System;
using EndProject.Domain.Entities;

namespace EndProject.Domain.Arguments.Player
{
   public class PlayerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string  Status { get; set; }

        public static explicit operator PlayerResponse(Entities.Player entidade)
        {
            return new PlayerResponse()
            {
                Email = entidade.Email.Address,
                Name = entidade.Name.FirstName,
                Id = entidade.Id
            };
        }
    }
}
