using System.ComponentModel.DataAnnotations;

namespace ProjetoRefugiados.Models
{
    public class Paises
    {
        [Key]
        public int Id { get; set; }
        public string Pais { get; set; }
        public string? Country { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}" +
                $"Nome: {Pais}" +
                $"Country: {Country}";
        }

    }
}
