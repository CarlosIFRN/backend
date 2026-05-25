using Microsoft.AspNetCore.Mvc;

namespace backend.Models
{
    public class Aluno
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}