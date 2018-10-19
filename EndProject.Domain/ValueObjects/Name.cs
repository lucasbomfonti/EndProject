using prmToolkit.NotificationPattern;

namespace EndProject.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new AddNotifications<Name>(this)
                .IfNullOrInvalidLength(x => x.FirstName, 3, 50, "FirstName is rquired")
                .IfNullOrInvalidLength(x => x.LastName, 3, 50, "LastName is rquired");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
