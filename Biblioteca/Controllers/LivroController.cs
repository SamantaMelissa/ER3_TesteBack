using Biblioteca.Models;
using Biblioteca.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    //Informar que utilizaremos o arquivo json para comunicação:
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;
        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            // IActionResult -> Retorna arquivos HTML, respostas HTTP...
            // NotFound() -> error 404
            try
            {
                Livro livro = _livroRepository.BuscarPorId(id);

                if (livro == null)
                {
                    return NotFound();
                }

                return Ok(livro);

            } catch (Exception) {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CadastrarLivro(Livro livro)
        {
            try
            {
                _livroRepository.CadastrarLivro(livro);

                return StatusCode(201);

            } catch (Exception) {

                throw;
            }
        }

        [HttpPut]

        public IActionResult AtualizarLivro(int id, Livro livro)
        {
            try
            {
                _livroRepository.AtualizarLivro(id, livro);
                return StatusCode(204);
            }catch(Exception) {
                throw;
            }
        }

    }
}
