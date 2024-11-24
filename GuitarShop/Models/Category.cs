using System.ComponentModel.DataAnnotations;

namespace GuitarShop.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter a category name.")]
        public string Name { get; set; }
        // A new property to identify stringed instruments
        public bool IsStringedInstrument { get; set; }


    }
}
