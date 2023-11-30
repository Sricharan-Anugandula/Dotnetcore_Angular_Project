using AutoMapper;
using firstapi.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace firstapi.Models
{
    public class BookRepo : IBookRepo
    {
        private readonly BookStoreContext _bookStoreContext;
        private readonly IMapper _mapper;

        public BookRepo(BookStoreContext bookStoreContext,IMapper mapper)
        {
         _bookStoreContext = bookStoreContext;
            _mapper = mapper;
        }
        async Task<List<BookModel>> IBookRepo. GetallbooksAsync()
        {
            // Without using automapper
            //var records = await _bookStoreContext.Books.Select(x => new BookModel()

            //{
            //    Id=x.Id,
            //    Title=x.Title,
            //    Description=x.Description
            //}).ToListAsync();

            //return records;

            //----------------using automapper-----------------------

            var records= await _bookStoreContext.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        async Task<BookModel> IBookRepo.getbookbyidasync(int id)
        {
            //------------------ Without using automapper---------------------------


            //var records = await _bookStoreContext.Books.Where(x=>x.Id==id).Select(x => new BookModel()

            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).FirstOrDefaultAsync();

            //return  records;

            //----------------using automapper-----------------------
            var book = await _bookStoreContext.Books.FindAsync(id);
            return _mapper.Map<BookModel>(book);
          
        }

        async Task<int> IBookRepo.AddaBook(BookModel bm)
        {
            var book = new Book()
            {
                Title=bm.Title,
               Description=bm.Description
            };
            _bookStoreContext.Books.Add(book);
            await _bookStoreContext.SaveChangesAsync(); 
            return book.Id;
        }

        async Task IBookRepo.UpdateBookAsync(int bookid,BookModel bm)
        {
            var book = new Book()
            {
                Id = bm.Id,
                Title = bm.Title,
                Description = bm.Description
            };
            _bookStoreContext.Books.Update(book);
            await _bookStoreContext.SaveChangesAsync();


        }

        public async Task UpdateBookPatchAsync(int bookid,  JsonPatchDocument bm)
        {
          var book= await _bookStoreContext.Books.FindAsync(bookid);

            if(book!=null)
            {
               bm.ApplyTo(book);
                await _bookStoreContext.SaveChangesAsync();
            }
        }



        async Task IBookRepo.DeleteBookAsync(int bookid)
        {
            var book = new Book()
            {
                Id =bookid,
                
            };
            _bookStoreContext.Books.Remove(book);
            await _bookStoreContext.SaveChangesAsync();


        }
    }
}
