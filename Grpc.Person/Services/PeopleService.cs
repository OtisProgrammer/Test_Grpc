using Application.Person.Commands;
using Application.Person.Interfaces;
using Grpc.Core;

namespace Grpc.Person.Services
{
    public class PeopleService : People.PeopleBase
    {
        private readonly IPersonService _personService;
        public PeopleService(IPersonService personService)
        {
            _personService = personService;
        }
        public override async Task<GetReply> Get(GetRequest request, ServerCallContext context)
        {
            var person = await _personService.GetById(request.Id);
            return new GetReply()
            {
                Id = person.Id,
                LastName = person.LastName,
                Mobile = person.Mobile,
                Age = person.Age,
                FirstName = person.FirstName,
            };
        }

        public override async Task<CreateReply> Create(CreateRequest request, ServerCallContext context)
        {
            var person = new PersonCommand()
            {
                Age = request.Age,
                Mobile = request.Mobile,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
            var result = await _personService.Create(person);
            return new CreateReply()
            {
                Result = result
            };
        }
    }
}
