using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        [Required(ErrorMessage = "Id richiesto")]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Nome richiesto")]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? ImgPath { get; set; }
        [Required(ErrorMessage = "Prezzo richiesto")]
        public string? Price { get; set; }

        public IFormFile? formFile { get; set; }

        public Pizza(int id, string nome, string? description, string? imgPath, double prezzo)
        {
            Id = id;
            Name = nome;
            Description = description;
            ImgPath = imgPath;
            Price = prezzo.ToString("0.00").Replace('.', ',');
        }

        public Pizza() { }
    }
}
