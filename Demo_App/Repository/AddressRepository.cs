using Dapper;
using Demo_App.Context;
using Demo_App.Contracts;
using Demo_App.Models;

namespace Demo_App.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DapperContext _context;

        public AddressRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Address> GetAddressDTOByPersonId(int personId)
        {
            var query = $"SELECT * FROM Address WHERE personId=@personId";

            using (var connection = _context.CreateConnection())
            {
                var address = await connection.QueryFirstAsync<Address>(query, new { personId });
                return address;
            }
        }

        public async Task<int> AddAddress(Address address)
        {
            var query = @"INSERT INTO Address(Street,House,City,State,Country,personId)
                        VALUES(@Street, @House, @City, @State, @Country, @personId);
                        SELECT CAST(SCOPE_IDENTITY() AS INT)";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteScalarAsync<int>(query, address);
                return result;
            }
        }
    }
}
