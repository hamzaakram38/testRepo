using AutoMapper;
using Demo_App.Contracts;
using Demo_App.Models;
using Demo_App.Repository;
using Demo_App.Services;
namespace Demo_App.Services
{
    public class AddressService: IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressDTO> getAddressDTOByPersonId(int personId)
        {
            var address=await _addressRepository.GetAddressDTOByPersonId(personId);
            Mapper mapper = Mappings.AddressToAddressDTOMapper.InitializeAutoMapper();
            return mapper.Map<AddressDTO>(address);
        }
        public async Task<Address> getAddressByPersonId(int personId)
        {
            var address = await _addressRepository.GetAddressDTOByPersonId(personId);
            return address;

        }

        public async Task<int> AddAddress(Address address)
        {
            var result = await _addressRepository.AddAddress(address);
            return result;
        }
    }
}
