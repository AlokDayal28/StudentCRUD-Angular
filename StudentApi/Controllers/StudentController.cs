using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Model;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _context;
        public StudentController(StudentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> Get()
        {
            var students = (from s in _context.Students
                          join st in _context.States
                          on s.StateId equals st.Id
                          join ct in _context.Cities
                          on s.CityId equals ct.Id

                          select new StudentViewModel
                          {
                              Id = s.Id,
                              Name = s.Name,
                              Email = s.Email,
                              Mobile = s.Mobile,
                              StateId=s.StateId,
                              CityId=s.CityId,
                              StateName = st.State_Name,
                              CityName = ct.City_Name,
                              AboutYourself = s.AboutYourself,
                              PhotoId = 1
                          }).ToListAsync();
            return await students;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if(student==null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpGet]
        [Route("Countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        [HttpGet]
        [Route("States")]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            return await _context.States.ToListAsync();
        }

        [HttpGet]
        [Route("State/{id}")]
        public async Task<ActionResult<IEnumerable<State>>> GetStates(int id)
        {
            return await _context.States.Where(s => s.Country_Id == id).ToListAsync();
        }

        [HttpGet]
        [Route("Cities")]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        [HttpGet]
        [Route("City/{id}")]
        public async Task<ActionResult<IEnumerable<City>>> GetCities(int id)
        {
            return await _context.Cities.Where(c => c.State_Id == id).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student student)
        {
            var stud = new Student
            {
                Name = student.Name,
                Email = student.Email,
                Mobile = student.Mobile,
                CityId = student.CityId,
                StateId = student.StateId,
                AboutYourself = student.AboutYourself,
                PhotoId = 1
            };
            _context.Students.Add(stud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = stud.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,Student student)
        {
            if (!StudentExist(id))
                return BadRequest();
            student.Id = id;
            student.StateId = student.StateId;
            student.CityId = student.CityId;

            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            
            return student;
        }
        private bool StudentExist(int id)
        {
            return _context.Students.Any(s => s.Id == id);
        }
    }
}
