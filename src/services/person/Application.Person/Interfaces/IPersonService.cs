using Application.Person.Commands;
using Application.Person.Query;

namespace Application.Person.Interfaces
{
    public interface IPersonService
    {
        Task<int> Create(PersonCommand person);
        Task<int> Update(PersonCommand person);
        Task Delete(int id);
        Task<PersonQuery> GetById(int id);
        Task<List<PersonQuery>> GetAll();
    }
}
