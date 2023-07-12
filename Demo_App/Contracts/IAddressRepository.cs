using Demo_App.Models;

namespace Demo_App.Contracts
{
    public interface IAddressRepository
    {
        public  Task<Address> GetAddressDTOByPersonId(int personId);
        public Task<int> AddAddress(Address address);
    }
}
