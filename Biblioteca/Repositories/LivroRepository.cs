using Biblioteca.Contexts;
using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public class LivroRepository
    {
        //
        private readonly BibliotecaContext _context;
        //
        public LivroRepository(BibliotecaContext context)
        {
            _context = context;
        }
        //Método que lista todos os livros
        public List<Livro> Listar() {
            return _context.Livros.ToList();
        }
        //Método que liste/busque(GET) o livro pelo id
        // id = 1 => Livro 1
        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        //Cadastrar(POST) os livros
        public void CadastrarLivro(Livro livro)
        {
            _context.Livros.Add(livro);

            _context.SaveChanges();
        }

        //Atualizar(PUT) os livros
        public void AtualizarLivro(int id, Livro livro)
        {
            Livro livroEncontrado = _context.Livros.Find(id);

            if(livroEncontrado != null)
            {
                // Aventuras 2.0 = Aventuras
                livroEncontrado.Titulo = livro.Titulo;
                livroEncontrado.QuantidadePaginas = livro.QuantidadePaginas;
                livroEncontrado.Disponivel = livro.Disponivel;
            }

            _context.Livros.Update(livroEncontrado);

            _context.SaveChanges();

        }

        public void DeletarLivro(int id)
        {
            Livro livro = _context.Livros.Find(id);

            _context.Livros.Remove(livro);

            _context.SaveChanges();
        }


    }
}
