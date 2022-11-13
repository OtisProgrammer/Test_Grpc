using Application.Person.Commands;
using Application.Person.Query;
using AutoMapper;

namespace Application.Person.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Domain.Person.Entities.Person, PersonCommand>().ReverseMap();
            CreateMap<Domain.Person.Entities.Person, PersonQuery>().ReverseMap();
        }
    }
}
