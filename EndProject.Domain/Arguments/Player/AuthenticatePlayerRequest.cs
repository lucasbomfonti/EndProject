using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndProject.Domain.ValueObjects;

namespace EndProject.Domain.Arguments.Player
{
   public class AuthenticatePlayerRequest
    {
        public string Email { get; set; }
        public string Password{ get; set; } 
    }
}
