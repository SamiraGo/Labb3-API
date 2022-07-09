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
    public class HobbyController : ControllerBase
    {
        private IRepository<Hobby> _hobbyRepos;

        public HobbyController(IRepository<Hobby> hobbyRepos)
        {
            _hobbyRepos = hobbyRepos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHobbies()
        {
            try
            {
                return Ok(await _hobbyRepos.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to GetAllHobbies data from Database...");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHobby(int id)
        {
            try
            {
                var single = await _hobbyRepos.GetSingle(id);
                if (single == null)
                {
                    return NotFound($"Could not find Hobby with ID {id} in database");
                }
                return Ok(single);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to GetHobby data from Database...");
            }
        }

        //[HttpPost("{id}")]
        //public async Task<ActionResult<Hobby>> AddHobby(Hobby newHobby)
        //{
        //    try
        //    {
        //        if (newHobby == null)
        //        {
        //            return BadRequest();
        //        }
        //        var newHobbyToAdd = await _hobbyRepos.Add(newHobby);
        //        return CreatedAtAction(nameof(GetHobby),
        //            new { id = newHobbyToAdd.HobbyId }, newHobbyToAdd);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error, failed to Create a new object to Database...");
        //    }
        //}
    }
}
