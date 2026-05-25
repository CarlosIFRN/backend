using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AlunosController : ControllerBase
    {
        private readonly EscolaDbContext _context;

        public AlunosController(EscolaDbContext context)
        {
            _context = context;
        }

        // GET: api/alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }

        // GET: api/alunos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound(new { mensagem = "Aluno não encontrado" });
            }

            return aluno;
        }

        // POST: api/alunos
        [HttpPost]
        public async Task<ActionResult<Aluno>> CreateAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAluno), new { id = aluno.ID }, aluno);
        }

        // PUT: api/alunos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, Aluno aluno)
        {
            if (id != aluno.ID)
            {
                return BadRequest(new { mensagem = "ID não coincide" });
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound(new { mensagem = "Aluno não encontrado" });
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/alunos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound(new { mensagem = "Aluno não encontrado" });
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.ID == id);
        }
    }
}