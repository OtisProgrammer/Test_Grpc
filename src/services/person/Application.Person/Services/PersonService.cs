using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Person.Commands;
using Application.Person.Interfaces;
using Application.Person.Query;
using AutoMapper;
using Domain.Person.Interfaces;

namespace Application.Person.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<int> Create(PersonCommand person)
        {
            try
            {
                var newPerson = _mapper.Map<Domain.Person.Entities.Person>(person);
                return await _personRepository.Create(newPerson);
            }
            catch (Exception e)
            {
                // todo log error
                return 0;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _personRepository.Delete(id);
            }
            catch (Exception e)
            {
                // todo log error
            }

        }

        public async Task<List<PersonQuery>> GetAll()
        {
            var people = await _personRepository.GetAll();
            return _mapper.Map<List<PersonQuery>>(people);
        }

        public async Task<PersonQuery> GetById(int id)
        {
            var person = await _personRepository.GetById(id);
            return _mapper.Map<PersonQuery>(person);
        }

        public async Task<int> Update(PersonCommand person)
        {
            try
            {
                var personForUpdate = await _personRepository.GetById(person.Id);
                if (personForUpdate != null)
                {
                    _mapper.Map(person, personForUpdate, typeof(PersonCommand), typeof(Domain.Person.Entities.Person));
                    await _personRepository.Update(personForUpdate);
                }

                return person.Id;
            }
            catch (Exception e)
            {
                // todo log error
                return 0;
            }
        }
    }
}
