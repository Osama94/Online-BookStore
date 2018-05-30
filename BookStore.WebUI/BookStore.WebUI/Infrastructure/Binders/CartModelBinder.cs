using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Infrastructure.Binders
{

    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

       

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //get Cart from session
            Cart cart = null;
            if (controllerContext.HttpContext.Session !=null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }


            if (cart==null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
                 return cart;
        }

        

        
    }
}