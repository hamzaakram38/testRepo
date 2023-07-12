using Demo_App.Models;

namespace Demo_App.Contracts
{
    public interface IPersonService
    {
        public Task<PersonDTO> GetPersonDTOByPersonId(int personId);
        public Task<Person> GetPersonByPersonId(int personId);
        public Task<int> AddPerson(Person person);
    }
}
