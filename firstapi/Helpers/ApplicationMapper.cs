using AutoMapper;
using firstapi.Controllers;
using firstapi.Data;
using firstapi.Models;

namespace firstapi.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book,BookModel>().ReverseMap();
        }

    }
}
