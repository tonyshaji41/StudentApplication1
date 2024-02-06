using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentApplication1.Models;
using StudentApplication1.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var studentList =  await studentRepository.GetAllAsync();
            return Ok(mapper.Map<List<StudentDto>> (studentList));
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var student = await studentRepository.GetByIdAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StudentDto>(student));
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentRequestDto student)
        {
            var studentDomainModel = mapper.Map<Student>(student);
            var studentResponse = await studentRepository.CreateAsync(studentDomainModel);
            var studentDto= mapper.Map<StudentDto>(studentResponse);
            return CreatedAtAction(nameof(Get), new {id= studentResponse.Id}, studentDto);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid  id, [FromBody] StudentRequestDto student)
        {
            var studentDomainModel = mapper.Map<Student>(student);
            var studentResponse = await studentRepository.UpdateAsync(id, studentDomainModel);
            if (studentResponse == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StudentDto>(studentResponse));
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedStudent = await studentRepository.DeleteAsync(id);
            if (deletedStudent == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StudentDto>(deletedStudent));
        }
    }
}
