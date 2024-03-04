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
    public class ChangeFirstNameCommandHandler
    {
        public ChangeFirstNameUserCommandResponse ChangeName(ChangeFirstNameUserCommandRequest request)
        {
            User user = UserSource.Users.FirstOrDefault(p => p.Id == request.Id);
            user.ChangeFirstName(request.NewName);
            return new ChangeFirstNameUserCommandResponse
            {
                User = user,
                NewName = request.NewName,
                OldName = request.OldName
            };
        }
    }
}
