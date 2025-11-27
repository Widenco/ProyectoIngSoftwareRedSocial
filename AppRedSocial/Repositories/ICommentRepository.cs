using AppRedSocial.Models;

namespace AppRedSocial.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> AddCommentAsycn(Comment comment);
        Task<bool> DeleteCommentAsycn(Comment comment);  
        Task<Comment> UpdateCommentAsycn(Comment comment, User user);
        Task<Comment> GetCommentByUserAsycn(User user);
        Task<Comment> GetCommentById(int id);
    }
}
