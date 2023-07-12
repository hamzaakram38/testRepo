using Demo_App.Models;

namespace Demo_App.Contracts
{
    public interface IAddressService
    {
        public Task<AddressDTO> getAddressDTOByPersonId(int personId);
        public Task<Address> getAddressByPersonId(int personId);
        public Task<int> AddAddress(Address address);
    }
}
