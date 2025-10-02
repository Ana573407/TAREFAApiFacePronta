using Microsoft.AspNetCore.Mvc;
using TarefaFAcebookApi.Context;
using TarefaFAcebookApi.Models;
using System;
using System.Linq;

namespace TarefaFAcebookApi.Controllers
{
    [ApiController]
   [Route("api/facebook")]
    public class FacebookController : ControllerBase
    {
        private readonly FacebookContext _context;

        public FacebookController(FacebookContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (usuario == null || string.IsNullOrWhiteSpace(usuario.Nome))
                return BadRequest(new { message = "Dados inválidos" });

            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return Ok(new { message = "Usuário cadastrado com sucesso!", usuario });
            }
            catch (Exception ex)
            {
                // Retorna erro detalhado para ajudar no debug (remova depois)
                return StatusCode(500, new { message = "Erro ao salvar usuário: " + ex.Message });
            }
        }

        // Outros métodos aqui (GET, PUT, DELETE) se desejar...
    }
}
