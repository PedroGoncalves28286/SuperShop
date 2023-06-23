using System;
using System.ComponentModel.DataAnnotations;

namespace SuperShop.Models
{
    public class DeliveryViewModel
    {
        public int Id { get; set; }




        [Display(Name = "Delivery Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }
    }
}