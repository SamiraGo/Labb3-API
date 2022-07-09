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
    public class LinksController : ControllerBase
    {
        private IRepository<Link> _linkRepos;

        public LinksController(IRepository<Link> linkRepos)
        {
            _linkRepos = linkRepos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLinks()
        {
            try
            {
                return Ok(await _linkRepos.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to GetAllLinks data from Database...");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLink(int id)
        {
            try
            {
                var single = await _linkRepos.GetSingle(id);
                if (single == null)
                {
                    return NotFound($"Could not find Link with ID {id} in database");
                }
                return Ok(single);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to GetLink data from Database...");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Link>> AddLink(Link newLink)
        {
            try
            {
                if (newLink == null)
                {
                    return BadRequest();
                }
                var newLinkToAdd = await _linkRepos.Add(newLink);
                return CreatedAtAction(nameof(GetLink),
                    new { id = newLinkToAdd.LinkId }, newLinkToAdd);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error, failed to Create a new object to Database...");
            }
        }
    }
}
