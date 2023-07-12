using Demo_App.Models;

namespace Demo_App.Contracts
{
    public interface IUserService
    {
        public Task<PersonDTO> GetUserByPersonId(int personId);
    }
}
