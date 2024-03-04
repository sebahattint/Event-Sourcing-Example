using EventSourcing.Application.Queries.UserQueries.Request;
using EventSourcing.Application.Queries.UserQueries.Response;
using EventSourcing.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Handlers
{
    public class GetAllUserQueryHandler
    {
        public List<GetAllUserQueryResponse> GetAll(GetAllUserQueryRequest request)
        {
            return UserSource.Users.Select(user => new GetAllUserQueryResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            }).ToList();
        }
    }
}
