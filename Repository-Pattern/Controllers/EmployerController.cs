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

        /// <summary>
        /// Retorna todos os usuario
        /// </summary>
        /// <returns>Objeto de detalhes do usuario</returns>
        /// <response code="404">Usuario não encontrado</response>
        /// <response code="200">Usuario encontrado</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployer()
        {
            var employer = await _employerRepository.GetAll();
            return Ok(employer);
        }

        /// <summary>
        /// Retornar detalhes de um usuario
        /// </summary>
        /// <param name="id">Identificador de usuario</param>
        /// <returns>Objeto de detalhes do usuario</returns>
        /// <response code="404">Usuario não encontrado</response>
        /// <response code="200">Usuario encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdEmployer(Guid id)
        {
            var employer = await _employerRepository.GetById(id);
            return Ok(employer);
        }

        /// <summary>
        /// Cadastrar um usuário
        /// </summary>
        /// <remarks>
        /// Requisição de exemplo: 
        ///{
        /// "name":"Teste",
        /// "email":Teste@email,
        /// "document":00000
        /// }
        /// </remarks>
        /// <param name="employer">Objeto com dados de cadastro de Usuário</param>
        /// <returns>Objeto recém-criado.</returns>
        /// <response code="201">Objeto criado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
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

        /// <summary>
        /// Atualizar dados do usuario
        /// </summary>
        /// <remarks>
        /// Requisição de exemplo: 
        ///{
        /// "name":"Teste",
        /// "email":Teste@email,
        /// "document":00000
        /// }
        /// </remarks>
        /// <param name="id">Identificador de usuario</param>
        /// <param name="employer">Objeto com dados de atualização do Usuário</param>
        /// <returns>Objeto Atualizado</returns>
        /// <response code="201">Objeto atualizado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
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

        /// <summary>
        /// Deletar um usuario
        /// </summary>
        /// <param name="id">Identificador do usuario</param>
        /// <returns>Usuario deletado</returns>
        /// <response code="204">Objeto deletado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
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
