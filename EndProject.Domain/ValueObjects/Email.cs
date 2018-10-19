using prmToolkit.NotificationPattern;

namespace EndProject.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;

            new AddNotifications<Email>(this).IfNotEmail(x => x.Address);
        }
    }
}
