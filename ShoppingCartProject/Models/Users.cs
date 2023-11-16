using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartProject.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        [Optional]
        public string PhoneNumber
        {
            get;
            set;
        }

    }


}
