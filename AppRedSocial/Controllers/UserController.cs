namespace AppRedSocial.Controllers
{
    using global::AppRedSocial.Data;
    using global::AppRedSocial.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    namespace AppRedSocial.Controllers
    {
        public class UserController : Controller
        {
            private readonly AppDbContext _context;

            public UserController(AppDbContext context)
            {
                _context = context;
            }

            // GET: /User
            public async Task<IActionResult> Index()
            {
                var users = await _context.Users
                    .Include(u => u.Role)
                    .ToListAsync();

                return View(users);
            }

            // GET: /User/Details/5
            public async Task<IActionResult> Details(int id)
            {
                var user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                    return NotFound();

                return View(user);
            }

            // GET: /User/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: /User/Create
            [HttpPost]
            public async Task<IActionResult> Create(User user)
            {
                if (!ModelState.IsValid)
                    return View(user);

                user.EmailConfirmed = false;
                user.RoleId = 1; // Por defecto podrías asignar un rol básico

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // GET: /User/Edit/5
            public async Task<IActionResult> Edit(int id)
            {
                var user = await _context.Users.FindAsync(id);

                if (user == null)
                    return NotFound();

                return View(user);
            }

            // POST: /User/Edit
            [HttpPost]
            public async Task<IActionResult> Edit(User user)
            {
                if (!ModelState.IsValid)
                    return View(user);

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // GET: /User/Delete/5
            public async Task<IActionResult> Delete(int id)
            {
                var user = await _context.Users.FindAsync(id);

                if (user == null)
                    return NotFound();

                return View(user);
            }

           
            [HttpPost, ActionName("Delete")]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var user = await _context.Users.FindAsync(id);

                if (user == null)
                    return NotFound();

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
        }
    }

}
