using BookStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IBookRepository repository;

        public NavController (IBookRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu( string specilization=null)
        {

            ViewBag.SelectedSpec = specilization;

            IEnumerable<string> spec = repository.Books
                .Select(b => b.Specialization)
                .Distinct();

            return  PartialView(spec);
        }
    }
}