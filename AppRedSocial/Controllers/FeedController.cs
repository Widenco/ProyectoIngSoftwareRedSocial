using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppRedSocial.Data;      // DbContext
using AppRedSocial.Models;    // modelos

namespace AppRedSocial.Controllers
{
    public class FeedController : Controller
    {
        private readonly AppDbContext _context;

        public FeedController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            // Cargar posts con el usuario creador y sus comentarios
            var posts = await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            return View(posts);
        }
    }
}

