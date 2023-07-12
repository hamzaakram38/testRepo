using AutoMapper;
using Demo_App.Contracts;
using Demo_App.Models;

namespace Demo_App.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDTO> GetPersonDTOByPersonId(int personId)
        {
            var person = await _personRepository.GetPersonByPersonId(personId);
            var mapper = Mappings.PersonToPersonDTOMapper.InitializeAutoMapper();
            var personDTO= mapper.Map<PersonDTO>(person);
            return personDTO;
        }

        public async Task<Person> GetPersonByPersonId(int personId)
        {
            var person = await _personRepository.GetPersonByPersonId(personId);
            return person;
        }

        public async Task<int> AddPerson(Person person)
        {
            int flag=await _personRepository.AddPerson(person);
            return flag;
        }
    }
}
