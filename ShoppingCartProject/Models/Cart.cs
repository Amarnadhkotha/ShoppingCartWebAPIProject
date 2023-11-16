using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

namespace ShoppingCartProject.Models
{
    internal sealed class OptionalAttribute : Attribute { }
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId {get;set;}

        // Foreign key to Product
        public int ProductId { get; set; }

        // Foreign key to Users
        public int UserId {get;set;}

        public int Quantity {get;set;}

        public Product Products { get; set; }

        public User Users { get; set; }

    }

    
    public class CreateCart
    {
        
        public  int ProductId { get; set; }

        // Foreign key to Users
        public int UserId { get; set; }

        [Optional]
        public int Quantity { get; set; } = 1;
            
    }

}
