using Microsoft.AspNetCore.JsonPatch;

namespace firstapi.Models
{
    public interface IBookRepo
    {

        public Task<List<BookModel>> GetallbooksAsync();
        Task<BookModel> getbookbyidasync(int id);

        Task<int> AddaBook(BookModel bm);

         Task UpdateBookAsync(int bookid, BookModel bm);
        Task UpdateBookPatchAsync(int bookid, JsonPatchDocument bm);
        Task DeleteBookAsync(int bookid);

    }
}
