using ProjetoRefugiados.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoRefugiados.Models
{
    public class Filho
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Genero Genero { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public Paises Pais{ get; set; }
        public int PaisId { get; set; }
        public Refugiado Parente { get; set; }
        public int ParenteId { get; set; }



    }
}
