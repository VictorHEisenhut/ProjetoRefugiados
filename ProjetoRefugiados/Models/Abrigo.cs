using System.ComponentModel.DataAnnotations;

namespace ProjetoRefugiados.Models
{
    public class Abrigo
    {
        [Key]
        public int Id { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

    }
}
