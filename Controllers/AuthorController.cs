using AutoMapper;
using Bookbox.Data;
using Bookbox.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase

    {
        private readonly BookBoxDbContext dbContext;
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;

        public AuthorController(BookBoxDbContext dbContext, IAuthorRepository authorRepository, IMapper mapper) 
        {
            this.dbContext = dbContext;
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }


        [HttpPost]

    }
}
