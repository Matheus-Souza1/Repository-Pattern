using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.Domain.Entities;
using Repository_Pattern.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Repository_Pattern.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerController(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployer()
        {
            var employer = await _employerRepository.GetAll();
            return Ok(employer);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdEmployer(Guid id)
        {
            var employer = await _employerRepository.GetById(id);
            return Ok(employer);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddEmployer([FromBody] Employer employer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var _employer = new Employer(employer.Name, employer.Email, employer.Document);

            _employerRepository.Add(_employer);
            return Ok(_employer);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateEmployer([FromBody]Employer employer, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var _employer = await _employerRepository.GetById(id);
            _employer.Update(employer.Name, employer.Email, employer.Document);

            _employerRepository.Update(_employer);

            return Ok(_employer);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteEmployer(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _employerRepository.Delete(id);
            return Ok();
        }
    }
}
