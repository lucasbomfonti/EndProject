using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndProject.Domain.Entities;
using EndProject.Domain.ValueObjects;

namespace EndProject.Domain.Arguments.Player
{
   public class AuthenticatePlayerResponse
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int  Status { get; set; }

        public static explicit operator AuthenticatePlayerResponse(Entities.Player entidade)
        {
            return new AuthenticatePlayerResponse()
            {
                Email = entidade.Email.Address,
                FirstName = entidade.Name.FirstName,
                Status = (int) entidade.Status
            };
        }
    }
}
