using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace RestoPizza.Models
{
    public class Pizza
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Display(Name = "Nom")]
        public string nom { get; set; }

        [Display(Name = "Prix")]
        public float prix { get; set; }

        [Display(Name = "Végétarienne")]
        public bool vegetarienne { get; set; }

        [JsonIgnore]
        [Display(Name = "Ingrédients")]
        public string ingredients { get; set; }

        [NotMapped] // Ne pas stocker en BDD
        [JsonPropertyName("ingredients")]
        public List<string> ListeIngredients
        {
            get
            {
                if (this.ingredients == null || this.ingredients.Count() <= 0)
                {
                    return null;
                }

                return this.ingredients.Split(", ").ToList();
            }
        }

    }
}
