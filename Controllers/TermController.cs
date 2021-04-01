using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LingoDictionary.Models;
using LingoDictionary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LingoDictionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {
        private readonly ITermRepository _repo;

        public TermController(ITermRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Term
        [HttpGet]
        public async Task<IEnumerable<Term>> Get()
        {
            return await _repo.GetAll();
        }

        // GET: api/Term/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Term> Get(string id)
        {
            return await _repo.GetById(id);
        }

        // POST: api/Term
        [HttpPost]
        public async Task Post([FromBody] Term value)
        {
            await _repo.Insert(value);
        }

        // PUT: api/Term/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Term/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
