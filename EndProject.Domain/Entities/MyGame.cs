using System;

namespace EndProject.Domain.Entities
{
   public class MyGame
    {
        public Guid Id { get; set; }
        public PlatformGame PlatformGame { get; set; }
        public bool Iwant { get; set; }
        public DateTime DateWant { get; set; }
        public bool Trade { get; set; }
        public bool Sell { get; set; }

    }
}
