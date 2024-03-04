using EventSourcing.Domain.Entites;

namespace EventSourcing.Application.Events.UserEvents
{
    public class UserCreatedEvent : IEvent
    {
        public User User { get; set; }
        public UserCreatedEvent(User user)
        {
            User = user;
        }
        public override string ToString() => $"Yeni kullanıcı oluşturuldu. Id : {User.Id}";
    }
}
