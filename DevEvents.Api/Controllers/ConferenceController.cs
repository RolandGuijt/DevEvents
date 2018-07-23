using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEvents.Api.Models;
using DevEvents.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DevEvents.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly Repository<Conference> _repository;

        public ConferenceController(Repository<Conference> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Conference>>> Get()
        {
            return await _repository.GetList(c => c.EndDate.Date <= DateTime.Now.Date);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Conference>> Get(string id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Conference conference)
        {
            await _repository.Create(conference);
        }

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] Conference conference)
        {
            await _repository.Update(id, conference);
        }
    }
}