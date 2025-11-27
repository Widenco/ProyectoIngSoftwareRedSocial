using AppRedSocial.Models;

namespace AppRedSocial.Repositories
{
    public interface IPostRepository
    {
        Task<Post> AddPostAsync(Post post);
        Task<Post> UpdatePostAsync(Post post);
        Task<bool> DeletePostAsync(Post post);    
        Task<Post> GetPostByIdAsync(int id);
        Task<Post> GetPostByUserAsync(User user);
    }
}
