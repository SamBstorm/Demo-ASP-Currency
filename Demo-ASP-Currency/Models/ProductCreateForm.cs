using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP_Currency.Models
{
    public class ProductCreateForm
    {
        [DisplayName("Nom du produit")]
        [Required(ErrorMessage = "Le nom du produit est obligatoire")]
        [MinLength(2, ErrorMessage = "Le nom du produit doit avoir minimum 2 caractères.")]
        [MaxLength(32, ErrorMessage = "Le nom du produit doit avoir maximum 32 caractères.")]
        public string ProductName { get; set; }

        [DisplayName("Prix")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Le prix du produit est obligatoire")]
        public decimal Price { get; set; }
    }
}
