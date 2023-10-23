using Biblioteca.Interfaces;
using Biblioteca.Models;
using Biblioteca.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Biblioteca.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepositorycs _iusuariosRepository;

        public LoginController(IUsuarioRepositorycs iusuariosRepository)
        {
            _iusuariosRepository = iusuariosRepository;
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel login)
        {
            Usuario usuarioLogado = _iusuariosRepository.Login(login.Email, login.Senha);

            if(usuarioLogado == null)
            {
                return Unauthorized(new { msg = "Usuário não existe!!!" });
            }
            //Claim são reinvidicações. São elementos que representam informações sobre um usuário autenticado em um sistema. 
            var minhasClaims = new[]
            {
                // Aqui estamos criando instancias
                //Rrepresenta o nome registrado para o e-mail em JWT
                new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email),
                //usada para fornecer um identificador exclusivo para o token JWT.
                new Claim(JwtRegisteredClaimNames.Jti, usuarioLogado.Id.ToString()),
                // usado para representar a função ou papel do usuário autenticado.
                new Claim(ClaimTypes.Role, usuarioLogado.Tipo)
            };

            //usada para assinar e verificar tokens JWT:
            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var meuToken = new JwtSecurityToken(
                issuer: "chapter.webapi",
                audience: "chapter.webapi",
                claims: minhasClaims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credenciais
            );

            return Ok(
                new { token = new JwtSecurityTokenHandler().WriteToken(meuToken) }
            );
        }

    }
} 

