namespace Domain.Person.Interfaces
{
    public interface IPersonRepository
    {
        Task<int> Create(Entities.Person person);
        Task<int> Update(Entities.Person person);
        Task Delete(int id);
        Task<Entities.Person> GetById(int id);
        Task<List<Entities.Person>> GetAll();
    }
}
