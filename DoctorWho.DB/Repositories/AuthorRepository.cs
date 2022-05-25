using DoctorWho.DB.Models;
using DoctorWho.DB.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{


    public class AuthorRepository:BaseRepository, IAuthorRepository
    {



        public AuthorRepository(DoctorWhoCoreDbContext doctorWhoCoreDbContext) : base(doctorWhoCoreDbContext)
        {
        }
        public async Task<Author> GetAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            return author;
        }
        public async Task updateAuthor(Author author ,int id)
        {
            var author2 = await _context.Authors.FindAsync(id);
            author2.AuthorName = author.AuthorName;
        }

        public void DeleteAuthor(int id)
        {


            //var x = context.Authors.Find(id);
            var x = _context.Authors.Where(d => d.AuthorId == 1).First();
            var episodes = x.Episodes.ToList();
            foreach( var episode in episodes )
            {
                _context.Episodes.Remove(episode);

            }
            if( x == null ) return;
            _context.Authors.Remove(x);
            _context.SaveChanges();
        }

    }
}
