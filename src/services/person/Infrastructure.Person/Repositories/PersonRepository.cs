using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Person.Interfaces;
using Infrastructure.Person.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Person.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _ctx;
        public PersonRepository(PersonDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<int> Create(Domain.Person.Entities.Person person)
        {
            await _ctx.People.AddAsync(person);
            return await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var personForDelete = await GetById(id);
            _ctx.People.Remove(personForDelete);
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<Domain.Person.Entities.Person>> GetAll()
        {
            return await _ctx.People.ToListAsync();
        }

        public async Task<Domain.Person.Entities.Person> GetById(int id) => await _ctx.People.FindAsync(id);

        public async Task<int> Update(Domain.Person.Entities.Person person)
        {
            _ctx.People.Update(person);
            return person.Id;
        }
    }
}
