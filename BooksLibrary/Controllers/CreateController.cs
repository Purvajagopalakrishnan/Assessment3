using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.Controllers
{
    public class CreateController : Controller
    {
        List<Books> book = new List<Books>()
        {
            new Books {Book_Name = "Book1", Quantity = 1},
            new Books {Book_Name = "Book2", Quantity = 4},
            new Books {Book_Name = "Book3", Quantity = 3}
        };
        public IActionResult Index()
        {
            return View(book);
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Books element)
        {
            foreach (var boo in book.ToList())
            {
                if (boo.Book_Name == element.Book_Name)
                {
                    boo.Quantity = boo.Quantity - 1;
                }

                if (boo.Quantity == 0)
                {
                    book.RemoveAll(x => x.Quantity == 0);
                }
            }
                return View("Index", book);
        } 



        public IActionResult Addbooks()
        {
              return View();
        } 

        [HttpPost]
        public IActionResult Addbooks(Books model)
        {
          book.Add(new Books() {Book_Name = model.Book_Name, Quantity = model.Quantity });
          return View("Index", book); 
        }
    }
}