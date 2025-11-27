using AppRedSocial.Data;
using AppRedSocial.Models;
using Microsoft.EntityFrameworkCore;

namespace AppRedSocial.Repositories
{
    public class PostRepository(AppDbContext _context) : IPostRepository
    {
        public async Task<Post> AddPostAsync(Post post)
        {
            var entry = await _context.Posts.AddAsync(post);
            return entry.Entity;
        }

        public Task<bool> DeletePostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p=>p.PostId== id);
        }

        public async Task<Post> GetPostByUserAsync(User user)
        {
            return await _context.Posts.FirstOrDefaultAsync(p=>p.UserId== user.Id);
        }

        public Task<Post> UpdatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
