using Demo_App.Contracts;
using Demo_App.Models;

namespace Demo_App.Services
{
    public class UserService: IUserService
    {
        private readonly IPersonService _personService;
        private readonly IAddressService _addressService;

        public UserService(IPersonService personService, IAddressService addressService)
        {
            _personService = personService;
            _addressService = addressService;
        }

        public async Task<PersonDTO> GetUserByPersonId(int personId)
        {
            AddressDTO address= await _addressService.getAddressDTOByPersonId(personId);
            PersonDTO personDTO=await  _personService.GetPersonDTOByPersonId(personId);
            personDTO.Address = address.fullAddress;
            return personDTO;
        }
    }
}
