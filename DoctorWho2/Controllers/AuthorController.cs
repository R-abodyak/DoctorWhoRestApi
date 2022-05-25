using AutoMapper;
using DoctorWho.DB.Models;
using DoctorWho.DB.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DoctorWho.DB.Resources;

namespace DoctorWho2.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController:ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorRepository authorRepository ,IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        [HttpPut]
        [Route("{authorId}")]
        public async Task<ActionResult<Author>> updateAuthor(int authorId ,AuthorDto authorDto)
        {
            var x = await _authorRepository.GetAuthorAsync(authorId);
            if( x == null ) return NotFound();
            var author = _mapper.Map<Author>(authorDto);
            await _authorRepository.updateAuthor(author ,authorId);
            _authorRepository.SaveChanges();
            return Ok(author);
        }


    }
}
