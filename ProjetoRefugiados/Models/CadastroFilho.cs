using System.ComponentModel.DataAnnotations;
using ProjetoRefugiados.Models.Enums;

namespace ProjetoRefugiados.Models
{
    public class CadastroFilho
    {
        [Key] 
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Genero Genero { get; set; }
        public Paises Pais { get; set; }
        public string Escolaridade { get; set; }

    }
}
