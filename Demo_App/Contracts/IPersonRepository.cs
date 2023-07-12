using Demo_App.Models;

namespace Demo_App.Contracts
{
    public interface IPersonRepository
    {
        public Task<Person> GetPersonByPersonId(int personId);
        public Task<int> AddPerson(Person person);
    }
}
