using EventSourcing.Domain.Entites;

namespace EventSourcing.Application.Commands.UserCommands.Response
{
    public class ChangeLastNameUserCommandResponse
    {
        public User User { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
    }
}
