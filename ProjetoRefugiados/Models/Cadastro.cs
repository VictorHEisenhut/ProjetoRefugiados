using System.ComponentModel.DataAnnotations;
using ProjetoRefugiados.Models.Enums;

namespace ProjetoRefugiados.Models
{
    public class Cadastro
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Genero Genero  { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public Paises Pais { get; set; }
        public CadastroFilho? Filho { get; set; }
        public Documento? Documento { get; set; }

    }
}
