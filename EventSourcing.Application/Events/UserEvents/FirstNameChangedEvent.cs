using EventSourcing.Domain.Entites;

namespace EventSourcing.Application.Events.UserEvents
{
    public class FirstNameChangedEvent : IEvent
    {
        public User User { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
        public FirstNameChangedEvent(User user, string oldName, string newName)
        {
            User = user;
            OldName = oldName;
            NewName = newName;
        }
        public override string ToString() => $"{User.Id} id li kullanıcının adı değiştirildi. Eski: {OldName}, Yeni: {NewName}";
    }
}
