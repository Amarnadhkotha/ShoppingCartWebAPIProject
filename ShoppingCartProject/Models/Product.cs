using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartProject.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId
        {
            get;
            set;
        }

        public string ProductName
        {
            get;
            set;
        }

        [Column(TypeName = "money")]
        public decimal Price
        {
            get;
            set;
        }

        [Optional]
        public Boolean InStock
        {
            get;
            set;
        }= true;
    }


}
