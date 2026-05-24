using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        public IActionResult TestarController()
        {
            return Ok(new { mensagem = "Olá! O Controller de clima está funcionando perfeitamente!" });
        }
    }
}