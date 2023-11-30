using firstapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;



namespace firstapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepo _bookRepo;

        public BooksController(IBookRepo bookRepo)
        {
           _bookRepo = bookRepo;
        }

        [HttpGet("")]
       public async Task<IActionResult> getallbooks()
        {
            var books = await _bookRepo.GetallbooksAsync();
            return Ok(books);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getbookbyid(int id)
        {
            var books = await _bookRepo.getbookbyidasync(id);
            if(books == null)
                return NotFound();
            return Ok(books);
        }


        [HttpPost("")]
        public async Task<IActionResult> addabook(BookModel bm)
        {
            var id = await _bookRepo.AddaBook(bm);
            return CreatedAtAction(nameof(getbookbyid),new {id=id,Controller="books"},id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateabook(int id, BookModel bm)
        {
            await _bookRepo.UpdateBookAsync(id, bm);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> updatePatchbook ([FromRoute]int id, [FromBody] JsonPatchDocument   bm)
        {
            await _bookRepo.UpdateBookPatchAsync(id, bm);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebook([FromRoute] int id)
        {
            await _bookRepo.DeleteBookAsync(id);
            return Ok();
        }

    }
}
