using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class EscolaDbContext : DbContext
    {
        public EscolaDbContext(DbContextOptions<EscolaDbContext> options) 
            : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
