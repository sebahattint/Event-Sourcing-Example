using EventSourcing.Application.Queries.UserQueries.Request;
using EventSourcing.Application.Queries.UserQueries.Response;
using EventSourcing.Domain.Entites;

namespace EventSourcing.Application.Handlers
{
    public class GetUserQueryHandler
    {
        public GetUserQueryResponse GetPerson(GetUserQueryRequest request)
        {
            User person = UserSource.Users.FirstOrDefault(p => p.Id == request.Id);
            return new GetUserQueryResponse
            {
                User = person
            };
        }
    }
}
