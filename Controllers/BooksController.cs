using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Model;
using my_book.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BooksController : ControllerBase
    {
       readonly BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpPost("Add-Book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBookWithAuthor(book);
            return Ok();
        }
        [HttpGet("showAllBooks")]
        public IActionResult ShowBooks()
        {
         var res = _bookService.getListOfBooks();
            return Ok(res);
        }
        [HttpGet("getBook")]
        public IActionResult getBook(int id)
        {
            var res = _bookService.getBookWithAuthor(id);
            return Ok(res);
        }
        [HttpPut("updateBook/{id}")]
        public IActionResult updateBook(int id,Book book)
        {
            var res = _bookService.upDateBook(id,book);
            return Ok(res);
        }
        [HttpDelete("deleteBook/{id}")]
        public IActionResult deleteBook(int id)
        {
            _bookService.deleteBook(id);
            return Ok();
        }
    }
}
