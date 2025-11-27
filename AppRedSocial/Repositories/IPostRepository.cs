using AppRedSocial.Models;

namespace AppRedSocial.Repositories
{
    public interface IPostRepository
    {
        Task<Post?> GetByIdAsync(int id);
        Task<IEnumerable<Post>> GetAllAsync();
        Task<IEnumerable<Post>> GetByUserIdAsync(int userId);
        Task AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(Post post);
    }
}
