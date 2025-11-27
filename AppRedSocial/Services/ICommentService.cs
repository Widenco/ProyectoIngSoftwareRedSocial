using AppRedSocial.Models;

namespace AppRedSocial.Services
{
    public interface ICommentService
    {
        Task<Comment> AddCommentAsync(int postId, string userName, string content);
        Task<IEnumerable<Comment>> GetCommentsByPostAsync(int postId);
        Task<bool> DeleteCommentAsync(int commentId, string userName);
    }
}
