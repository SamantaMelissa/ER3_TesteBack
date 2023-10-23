using Biblioteca.Models;
using Biblioteca.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _usuarioRepository.CadastrarUsuario(usuario);

                return StatusCode(201);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {
            try
            {
                _usuarioRepository.AtualizarUsuario(id, usuario);

                return StatusCode(204);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
