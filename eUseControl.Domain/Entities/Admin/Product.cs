
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace eUseControl.Domain.Entities.Admin
{
    public class Product
    {
        //Id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Name
        public string Name { get; set; }

        //Price
        public decimal Price { get; set; }

        //Category
        public string Category { get; set; }

        public string ImagePath { get; set; }
    }
}
