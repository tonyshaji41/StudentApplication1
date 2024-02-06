using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentApplication1.Models;
using StudentApplication1.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IMarkRepository markRepository;
        private readonly IMapper mapper;

        public MarksController(IMarkRepository markRepository, IMapper mapper)
        {
            this.markRepository = markRepository;
            this.mapper = mapper;
        }
        // GET: api/<MarksController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var marklist = await markRepository.GetAllAsync();
            return Ok(mapper.Map<List<MarkDto>>(marklist));
        }

        // GET api/<MarksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
           var marks = await markRepository.GetByIdAsync(id);
           if (marks == null)
            {
                return NotFound();
            }
           return Ok(mapper.Map<MarkDto>(marks));
        }

        // POST api/<MarksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MarkRequestDto marks)
        {
            var marksDomainModel = mapper.Map<Mark>(marks);
            var markResponse = await markRepository.CreateAsync(marksDomainModel);
            return Ok(markResponse);
        }

        // PUT api/<MarksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] MarkRequestDto marks)
        {
            var marksDomainModel = mapper.Map<Mark>(marks);
            var marksResponse = await markRepository.UpdateAsync(id, marksDomainModel); 
            if(marksResponse == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<MarkDto>(marksResponse));
        }

        // DELETE api/<MarksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var marksResponse = await markRepository.DeleteAsync(id);
            if (marksResponse == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<MarkDto>(marksResponse));

        }
    }
}
