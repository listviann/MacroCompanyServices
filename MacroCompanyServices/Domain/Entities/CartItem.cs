using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacroCompanyServices.Domain.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; }

        [ForeignKey("ProductId")]
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }

        [ForeignKey("UserId")]
        public Guid? UserId { get; set; }
    }
}
