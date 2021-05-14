using AuthorsService.BAL;
using AuthorsService.BAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsManager _authorsManager;

        public AuthorsController(IAuthorsManager authorsManager)
        {
            _authorsManager = authorsManager;
        }

        // GET: api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetById(int id)
        {
            var result = await _authorsManager.GetByIdAsync(id);
            return Ok(result);
        }

        // GET: api/<AuthorsController>/all/true
        [HttpGet("all/{onlyActive}")]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll(bool onlyActive = true)
        {
            try
            {
                var result = await _authorsManager.GetAllAsync(onlyActive);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return Ok(ex.StackTrace);
            }
        }

        [HttpPost]
        // POST: api/<AuthorsController>
        public async Task<ActionResult<AuthorDto>> AddOrUpdate([FromBody] AuthorDto author)
        {
            var result = await _authorsManager.AddOrUpdateAsync(author);
            return Ok(result);
        }
    }
}

