using EventSourcing.Application.Commands.UserCommands.Request;
using EventSourcing.Application.Events;
using EventSourcing.Application.Queries.UserQueries.Request;

namespace EventSourcing.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventBroker eventBroker = new EventBroker();
            eventBroker.Command(new CreateUserCommandRequest() { Id = 4, FirstName = "Test", LastName = "Test" });
            eventBroker.Command(new CreateUserCommandRequest() { Id = 5, FirstName = "Test 2", LastName = "Test 2" });
            eventBroker.Command(new ChangeFirstNameUserCommandRequest() { Id = 3, OldName = "Burhan", NewName = "Orhan" });
            eventBroker.Command(new ChangeLastNameUserCommandRequest() { Id = 3, OldLastName = "Tonbul", NewLastName = "Küçük" });
            eventBroker.WriteAllEvent();
            eventBroker.Query(new GetAllUserQueryRequest());
        }
    }
}
