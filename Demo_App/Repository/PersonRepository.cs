using Dapper;
using Demo_App.Context;
using Demo_App.Contracts;
using Demo_App.Models;

namespace Demo_App.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DapperContext _context;

        public PersonRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Person> GetPersonByPersonId(int personId)
        {
            var query = $"SELECT * FROM Person WHERE Id=@personId";

            using (var connection = _context.CreateConnection())
            {
                var person = await connection.QueryFirstAsync<Person>(query, new { personId });
                return person;
            }
        }

        public async Task<int> AddPerson(Person person)
        {
            //var query = $"INSERT INTO Person(FirstName, LastName, Phone, FatherName, MotherName) VALUES(@FirstName, @LastName, @Phone, @FatherName, @MotherName)";

            var query = @"
                            INSERT INTO Person(FirstName, LastName, Phone, FatherName, MotherName) 
                            VALUES(@FirstName, @LastName, @Phone, @FatherName, @MotherName);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (var connection = _context.CreateConnection())
            {
                var rowsAffected = await connection.ExecuteScalarAsync<int>(query,person);
                return rowsAffected;
            }
        }
    }
}
