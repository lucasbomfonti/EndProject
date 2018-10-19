using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndProject.Domain.ValueObjects;

namespace EndProject.Domain.Arguments.Player
{
   public class AddPlayerRequest 
    {
        public Name Name { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
    }
}
