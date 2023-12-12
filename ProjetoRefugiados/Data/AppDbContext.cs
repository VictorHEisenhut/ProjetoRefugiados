using Microsoft.EntityFrameworkCore;
using ProjetoRefugiados.Models;

namespace ProjetoRefugiados.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Refugiado> Refugiados { get; set; }
        public DbSet<Filho> Filhos { get; set; }
        public DbSet<Paises> Paises { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Consulado> Consulados { get; set; }
        public DbSet<PostoDeSaude> PostosDeSaude { get; set; }
        public DbSet<Abrigo> Abrigos { get; set; }


        //Criando e usando a connection string
        static readonly string connectionString = @"Server=localhost;Database=refugiados_db;Uid=root;Pwd=admin";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
