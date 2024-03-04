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
    public class ChangeLastNameCommandHandler
    {
        public ChangeLastNameUserCommandResponse ChangeName(ChangeLastNameUserCommandRequest request)
        {
            User user = UserSource.Users.FirstOrDefault(p => p.Id == request.Id);
            user.ChangeLastName(request.NewLastName);
            return new ChangeLastNameUserCommandResponse
            {
                User = user,
                NewName = request.NewLastName,
                OldName = request.OldLastName
            };
        }
    }
}
