using DoctorWho.DB.Models;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> GetAuthorAsync(int id);
        Task updateAuthor(Author author ,int id);
        void DeleteAuthor(int id);
        Task SaveChanges();
    }
}