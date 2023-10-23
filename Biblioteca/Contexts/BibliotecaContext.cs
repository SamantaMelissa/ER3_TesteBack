
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Contexts
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext() { }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Caso as informações vierem vazias, ele vai entrar dentro do if
            if (!optionsBuilder.IsConfigured)
            {
                //Data source – Nome que está lá no banco de dados;
                //initial catalog – Nome do banco
                //Integrated Security -- se você está utilizando a segurança do windows para conectar no banco

                optionsBuilder.UseSqlServer("Data Source = DESKTOP-TQQ48UH\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true; TrustServerCertificate = true;");
            }
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
