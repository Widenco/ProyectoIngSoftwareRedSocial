using AppRedSocial.Data;
using AppRedSocial.Models;
using Microsoft.EntityFrameworkCore;

namespace AppRedSocial.Repositories
{
    public class CommentRepository(AppDbContext _context) : ICommentRepository
    {
        public async Task<Comment> AddCommentAsycn(Comment comment)
        {
            var entry = await _context.Comments.AddAsync(comment);
            return entry.Entity;
        }

        public Task<bool> DeleteCommentAsycn(Comment comment)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c=>c.CommentId== id);
        }

        public async Task<Comment> GetCommentByUserAsycn(User user)
        {
            return await _context.Users.Include(u=> u.Role).FirstOrDefaultAsync(c=>c.UserId = user.Id);
        }

        public Task<Comment> UpdateCommentAsycn(Comment comment, User user)
        {
            throw new NotImplementedException();
        }
    }
}
