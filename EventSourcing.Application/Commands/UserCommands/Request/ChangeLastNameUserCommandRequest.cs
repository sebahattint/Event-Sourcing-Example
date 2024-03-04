using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.UserCommands.Request
{
    public class ChangeLastNameUserCommandRequest
    {
        public int Id { get; set; }
        public string OldLastName { get; set; }
        public string NewLastName { get; set; }
    }
}
