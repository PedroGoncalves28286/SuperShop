using System.ComponentModel.DataAnnotations;

namespace SuperShop.Data.Entities
{
    public class OrderDetailTemp : IEntity
    {
        public int Id { get; set; }

        [Required] 

        public User user { get; set; }
        public User User { get; internal set; }
        [Required]  

        public Product Product { get; set; }

        [DisplayFormat (DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Quantity { get; set; }

     
    }
    
   
}
