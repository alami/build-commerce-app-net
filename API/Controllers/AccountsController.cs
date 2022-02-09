using Core.Models.Billing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _repo;

        public AccountsController(IAccountRepository repo)
        {
            this._repo = repo;
        }
        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<ActionResult<List<Account>>> Get()
        {
            var accounts = await _repo.GetAccountAsync();

            return Ok(accounts);
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> Get(string id)
        {
            return await _repo.GetAccountByIdAsync(id);
        }

        // POST api/<AccountsController>
        [HttpPost]
        public void Post([FromBody] string account)
        {
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string account)
        {
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
