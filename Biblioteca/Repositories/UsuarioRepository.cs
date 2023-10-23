using Biblioteca.Contexts;
using Biblioteca.Interfaces;
using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public class UsuarioRepository : IUsuarioRepositorycs
    {
        private readonly BibliotecaContext _context;

        public UsuarioRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

            _context.SaveChanges();
        }

        public void AtualizarUsuario(int id, Usuario usuario)
        {
            Usuario usuarioIdentificado = _context.Usuarios.Find(id);

            if (usuarioIdentificado != null)
            {
                //email@email.com ----> samanta@email.com
                usuarioIdentificado.Email = usuario.Email;
                usuarioIdentificado.Senha = usuario.Senha;
                usuarioIdentificado.Tipo = usuario.Tipo;

            }

            _context.Usuarios.Update(usuarioIdentificado);

            _context.SaveChanges();

        }

        public Usuario Login(string email, string senha)
        {
           return _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }
    }
}
