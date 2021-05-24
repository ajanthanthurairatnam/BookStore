using BookStore.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices bookServices;


        public BooksController(IBookServices bookServices)
        {
            this.bookServices = bookServices;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(bookServices.GetBooks());
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(string id)
        {
            return Ok(bookServices.GetBook(id));
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            bookServices.AddBook(book);
            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            bookServices.DeleteBook(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            return Ok(bookServices.UpdateBook(book));
        }

    }
}
