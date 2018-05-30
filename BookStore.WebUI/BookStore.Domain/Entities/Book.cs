using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookStore.Domain.Entities
{
    public class Book
    {
        [Key]
        public int ISBN { get; set; }
        [Required(ErrorMessage ="Please Enter book Title")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please Enter book Description")]
        public string Description  { get; set; }
        [Required(ErrorMessage = "Please Enter book Price")]
        [Range(10,9999.99, ErrorMessage = "Please Enter Valid Price")]
        public decimal Price { get; set; }
        [Required]
        public string Specialization { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }


    }
}
