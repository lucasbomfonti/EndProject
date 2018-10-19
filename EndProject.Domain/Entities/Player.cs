using System;
using EndProject.Domain.Entities.Base;
using EndProject.Domain.Enum;
using EndProject.Domain.Extensions;
using EndProject.Domain.ValueObjects;
using prmToolkit.NotificationPattern;

namespace EndProject.Domain.Entities
{
    public class Player : EntityBase
    {
     
        public Player(Email email, string password)
        {
            Email = email;
            Password = password;
            new AddNotifications<Player>(this)
                .IfNullOrInvalidLength(x => x.Password, 6, 32, "Password Invalid");       
        }

        public Player(Name name, Email email, string password)
        {
            Name = name;
            Email = email;    

            new AddNotifications<Player>(this)
                .IfNullOrInvalidLength(x => x.Password, 6, 32);
            if (IsValid())
            {
                Password = password.ConvertToMD5();
            }

            AddNotifications(name, email);
        }

        public void ChangePlayer(Name name, Email email, EnumStatusPlayer status)
        {
            Name = name;
            Email = email;
            new AddNotifications<Player>(this).IfFalse(Status == EnumStatusPlayer.Active,
                "not is possible change player not active");
            AddNotifications(name, email);

        }

        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public EnumStatusPlayer Status { get; private set; }
    }
}
