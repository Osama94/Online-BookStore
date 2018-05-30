using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { set; get; }
        public string ReturnUrl { set; get; }

    }
}