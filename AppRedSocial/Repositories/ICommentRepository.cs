using AppRedSocial.Models;

namespace AppRedSocial.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment?> GetByIdAsync(int id);
        Task<IEnumerable<Comment>> GetByPostIdAsync(int postId);
        Task AddAsync(Comment comment);
        Task DeleteAsync(Comment comment);
    }
}
