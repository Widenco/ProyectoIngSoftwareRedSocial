using AppRedSocial.Models;

namespace AppRedSocial.Services
{
    public interface IPostService
    {
        Task<Post> CreatePostAsync(string userName, string content);
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<IEnumerable<Post>> GetPostsByUserAsync(int userId);
        Task<Post?> GetPostByIdAsync(int postId);
        Task<bool> UpdatePostAsync(int postId, string userName, string newContent);
        Task<bool> DeletePostAsync(int postId, string userName);
    }
}
