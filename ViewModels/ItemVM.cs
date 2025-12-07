using learn_entity_framework.Models;
using System.ComponentModel.DataAnnotations;

namespace learn_entity_framework.ViewModels
{
    public class ItemVM
    {
        [Required(ErrorMessage = "The name is required")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "The price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "The category is required")]
        public int Category { get; set; }
    }
}
