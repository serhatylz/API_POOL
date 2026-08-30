using JSON_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace JSON_API.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IEnumerable<Book> books = DemoData.GetDemoBooks();
        // GET: api/Books
        public IHttpActionResult Get()
        {
            if (books.Count() > 0)
            {
                return Ok(books); //200
            }
            else
            {
                return Content(HttpStatusCode.NotFound, new { message = "We don't find any book in your bookshelf!" }); //404
            }

        }

        // GET: api/Books/5
        public IHttpActionResult Get(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                return Ok(book); //200
            }
            else
            {
                return Content(HttpStatusCode.NotFound, new { message = "We don't find this book in your bookshelf!" }); //404
            }
        }

        // POST: api/Books
        public IHttpActionResult Post([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Your body not complete!"); //400
            }

            if (book == null)
            {
                return NotFound(); //404
            }

            book.Id = books.LastOrDefault().Id + 1;
            var location = new Uri(Request.RequestUri + "/" + book.Id); //api/Books/{id}
            return Created(location, book); //201
        }

        // PUT: api/Books/5
        public IHttpActionResult Put(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Your body not complete!"); //400
            }

            if (book == null)
            {
                return NotFound(); //404
            }

            return Content(HttpStatusCode.NoContent, book); //204 with response

        }

        // DELETE: api/Books/5
        public IHttpActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null) return NotFound(); //404
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
