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
    public class AuthorController : ControllerBase
    {
        readonly AuthorService _authorservice;
        public AuthorController(AuthorService authorService)
        {
            _authorservice = authorService;
        }

        [HttpPost("Add-Author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author )
        {
            _authorservice.AddAuthor(author);

            return Ok();
        }
        //
        
        //
        [HttpGet("AuthorBooks")]
        public IActionResult getAuthBook(int id)
        {
          var res=  _authorservice.getAuthorBook(id);

            return Ok(res);
        }

    }
}
