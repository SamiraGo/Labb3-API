using Labb3_API.Models;
using Labb3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonHobbiesController : ControllerBase
    {
        private IRepository<PersonHobby> _personHobbyRepository;

        public PersonHobbiesController(IRepository<PersonHobby> personHobbyRepository)
        {
            _personHobbyRepository = personHobbyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _personHobbyRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to GetAllPersons data from Database...");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                var single = await _personHobbyRepository.GetSingle(id);
                if (single == null)
                {
                    return NotFound();
                }
                return Ok(single);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve single data from Database...");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonHobby>> AddPersonToHobby(PersonHobby personHobby)
        {
            try
            {
                if (personHobby == null)
                {
                    return BadRequest();
                }
                var newPersonHobby = await _personHobbyRepository.Add(personHobby);
                return CreatedAtAction(nameof(GetSingle),
                    new { id = newPersonHobby.PersonHobbyId }, newPersonHobby);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error, failed to Create a new object to Database...");
            }

        }
    }
}
