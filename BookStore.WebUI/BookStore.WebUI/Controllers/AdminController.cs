using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IBookRepository repository;
        public AdminController(IBookRepository repo)
        {
            repository = repo;
        }

        [HttpPost]
        public ViewResult Index(string searchValue)
        {
            IEnumerable<Book> books;

            books = from b in repository.Books

                    where /*b.Description.IndexOf(searchValue) >= 0 ||*/
                          b.Title.IndexOf(searchValue) >= 0 //||
                          //b.Specialization.IndexOf(searchValue) >= 0
                    select b;

            return View("Index", books);

        }

        public ViewResult Index()
        {
            return View("Index", repository.Books);
        }

        public ViewResult Edit(int ISBN)
        {
            Book book = repository.Books.FirstOrDefault(b => b.ISBN == ISBN);

            return View(book);
        }
        
        //[HttpPost]
        //public ActionResult Edit(Book book)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        repository.SaveBook(book);
        //        TempData["message"] =  book.Title +" Has been Saved Successfully !!";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {


        //        return View(book);
        //    }

        //}

        public ViewResult Create()
        {
            

            return View("Edit",new Book());
        }

        [HttpGet]
        public ActionResult Delete(int ISBN)
        {
            Book deletedBook = repository.DeleteBook(ISBN);
            if (deletedBook !=null)
            {
                TempData["message"] = deletedBook.Title +" Was Deleted Successfully !!";
                
            }
            return RedirectToAction("Index");

         
        }

        [HttpPost]
        public ActionResult Edit(Book book, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    book.ImageMimeType = image.ContentType;
                    book.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(book.ImageData,0, image.ContentLength);
                }
                repository.SaveBook(book);
                TempData["message"] = book.Title + " Has been Saved Successfully !!";

                //TempData["message"] = string.Format("Has been Saved Successfully !! {0} ", book.Title);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }





    }
}