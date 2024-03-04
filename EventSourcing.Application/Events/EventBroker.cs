using EventSourcing.Application.Commands.UserCommands.Request;
using EventSourcing.Application.Commands.UserCommands.Response;
using EventSourcing.Application.Events.UserEvents;
using EventSourcing.Application.Handlers;
using EventSourcing.Application.Queries.UserQueries.Request;
using EventSourcing.Application.Queries.UserQueries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Events
{
    public class EventBroker
    {
        public List<IEvent> AllEvents { get; set; } = new();
        public event EventHandler<object> Commands;
        public event EventHandler<object> Queries;

        public EventBroker()
        {
            this.Commands += (sender, command) =>
            {
                if (command is ChangeFirstNameUserCommandRequest req1)
                {
                    ChangeFirstNameCommandHandler handler = new ChangeFirstNameCommandHandler();
                    ChangeFirstNameUserCommandResponse response = handler.ChangeName(req1);
                    AllEvents.Add(new FirstNameChangedEvent(response.User, response.OldName, response.NewName));
                }
                else if (command is ChangeLastNameUserCommandRequest req2)
                {
                    ChangeLastNameCommandHandler handler = new ChangeLastNameCommandHandler();
                    ChangeLastNameUserCommandResponse response = handler.ChangeName(req2);
                    AllEvents.Add(new LastNameChangedEvent(response.User, response.OldName, response.NewName));
                }
                else if (command is CreateUserCommandRequest req3)
                {
                    CreateUserCommandHandler handler = new CreateUserCommandHandler();
                    CreateUserCommandResponse response = handler.CreateUser(req3);
                    AllEvents.Add(new UserCreatedEvent(response.User));
                }
            };

            this.Queries = (sender, query) =>
            {
                if (query is GetUserQueryRequest req1)
                {
                    GetUserQueryHandler handler = new GetUserQueryHandler();
                    GetUserQueryResponse response = handler.GetPerson(req1);
                    Console.WriteLine($"Id\tFirstName\tLastName");
                    Console.WriteLine($"{response.User.Id}\t{response.User.FirstName}\t{response.User.LastName}");
                }
                else if (query is GetAllUserQueryRequest req2)
                {
                    GetAllUserQueryHandler handler = new GetAllUserQueryHandler();
                    List<GetAllUserQueryResponse> response = handler.GetAll(req2);
                    Console.WriteLine($"Id\tFirstName\tLastName");
                    response.ForEach(user => Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.LastName}"));
                    Console.WriteLine("-------------------------------------");
                }
            };
        }
        public void Command(object command) => Commands(this, command);
        public void Query(object query) => Queries(this, query);
        public void WriteAllEvent() => AllEvents.ForEach(@event => Console.WriteLine($"{@event.ToString()}\n************"));
    }
}
