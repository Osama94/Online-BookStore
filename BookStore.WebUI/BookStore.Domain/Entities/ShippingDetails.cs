using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
   public class ShippingDetails
    {
        [Required(ErrorMessage ="Please Enter A Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter The First Address Line")]
        [Display(Name= "Address Line 1")]
        public string Line1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string Line2 { get; set; }
        [Required(ErrorMessage = "Please Enter The City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Your Mobile Number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter The Country Name")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }

    }
}
