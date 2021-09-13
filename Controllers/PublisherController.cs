using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class PublisherController : ControllerBase
    {
       readonly   PublisherService _publisherSerice;
        readonly ILogger<PublisherController> _ILogger;
        public PublisherController(PublisherService publisherService, ILogger<PublisherController> ILogger)
        {
            _publisherSerice = publisherService;
            _ILogger = ILogger;
        }


        [HttpGet("ShowAllPublisher")]
        public IActionResult showAllPublisher(string sortBy,string searchText)
        {
            _ILogger.LogInformation("Logging to file");
            var result = _publisherSerice.showAllPublisher(sortBy, searchText);
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Sorry We could not load you Data");
            }
        }


        [HttpPost("Add-Pusblisher")]
        public IActionResult AddAuthor([FromBody] PublisherVM publisher)
        {
          var result=  _publisherSerice.AddPublisher(publisher);
            if(result != null)
            {
                return Created(nameof(AddAuthor), result);
            }
            else
            {
                return Conflict("Could not process you request");
            }

          
        }

        [HttpGet("ShowPublisherWitAuthorAndName/{id}")]
        public IActionResult getPulisherById(int id)
        {
           
            try
            {
                var res = _publisherSerice.getPublisherById(id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
          
        }
    }
}
