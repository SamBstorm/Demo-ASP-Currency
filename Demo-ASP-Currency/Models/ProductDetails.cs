using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP_Currency.Models
{
    public class ProductDetails
    {
        [ScaffoldColumn(false)]
        public Guid ProductId { get; set; }
        [DisplayName("Nom du produit")]
        public string ProductName { get; set; }
        [DisplayName("Prix")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
