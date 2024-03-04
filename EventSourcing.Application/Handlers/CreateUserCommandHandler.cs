using EventSourcing.Application.Commands.UserCommands.Request;
using EventSourcing.Application.Commands.UserCommands.Response;
using EventSourcing.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Handlers
{
    public class CreateUserCommandHandler
    {
        public CreateUserCommandResponse CreateUser(CreateUserCommandRequest request)
        {
            var user = new User(request.Id, request.FirstName, request.LastName);
            UserSource.Users.Add(user);
            return new CreateUserCommandResponse()
            {
                User = user
            };
        }
    }
}

