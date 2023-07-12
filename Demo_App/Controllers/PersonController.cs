using Demo_App.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo_App.Services;
using Demo_App.Models;
using System.Runtime.CompilerServices;

namespace Demo_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPersonService _personService;
        private readonly IAddressService _addressService;

        public PersonController(IUserService userService, IPersonService personService, IAddressService addressService)
        {
            _userService = userService;
            _personService = personService;
            _addressService = addressService;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> Get([FromRoute] int Id)
        {
            PersonDTO person = await _userService.GetUserByPersonId(Id);
            return Ok(person);
        }

        [HttpPost]

        public async Task<ActionResult<Person>> CreatePerson([FromBody]Person person)
        {
            try
            {
                if (person == null)
                    return BadRequest();
                else
                {
                    int personId = await _personService.AddPerson(person);
                    var address = person.address;
                    address.personId = personId;
                    int addressId = await _addressService.AddAddress(address);
                    person.Id = personId;
                    person.address.Id = addressId;
                        return Ok(person);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
