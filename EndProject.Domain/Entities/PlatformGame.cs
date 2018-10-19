using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndProject.Domain.Entities
{
   public class PlatformGame
    {
        public Guid Id { get; set; }
        public Game Game { get; set; }
        public Platform Platform { get; set; }
        public DateTime StartDate { get; set; }

    }
}
