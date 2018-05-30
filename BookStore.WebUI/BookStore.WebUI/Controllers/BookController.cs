using BookStore.Domain.Abstract;
using BookStore.Domain.Concrete;
using BookStore.Domain.Entities;
using BookStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class BookController : Controller
    {

        private IBookRepository repository;
        public int PageSize=4;

        public BookController(IBookRepository bookRep)
        {
            repository = bookRep;
        }

        public ViewResult List(string specilization, int Pageno = 1)
            {
            BookListViewModel model = new Models.BookListViewModel();
            PagingInfo pInfo = new PagingInfo();
            model.Books = repository.Books

                   .Where(b => specilization == null || b.Specialization == specilization)
                   .OrderBy(b => b.ISBN)
                   .Skip((Pageno - 1) * PageSize)
                   .Take(PageSize);

            pInfo.CurrentPage = Pageno;
            pInfo.ItemsPerPage = PageSize;
            pInfo.TotalItems = (specilization == null) ?
            repository.Books.Count() :
            repository.Books.Where(b => b.Specialization == specilization).Count();

            model.PagingInfo = pInfo;
            model.CurrentSpecilization = specilization;

            return View(model);
        }



        public FileContentResult GetImage(int ISBN)
        {
            Book book = repository.Books.FirstOrDefault(p => p.ISBN == ISBN);
            if (book != null)
            {
                return File(book.ImageData, book.ImageMimeType);
            }
            else
            {
                return null;
            }
        }


    }
}
