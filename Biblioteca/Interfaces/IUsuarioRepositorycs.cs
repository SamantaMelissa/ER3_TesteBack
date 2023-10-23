using Biblioteca.Models;

namespace Biblioteca.Interfaces
{
    public interface IUsuarioRepositorycs
    {
        Usuario Login(string email, string senha);
    }
}
