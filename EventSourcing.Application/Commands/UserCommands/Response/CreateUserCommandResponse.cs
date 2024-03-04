using EventSourcing.Domain.Entites;

namespace EventSourcing.Application.Commands.UserCommands.Response
{
    public class CreateUserCommandResponse
    {
        public User User { get; set; }
    }
}
