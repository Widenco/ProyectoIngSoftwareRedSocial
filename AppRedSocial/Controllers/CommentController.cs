namespace AppRedSocial.Controllers
{

    using global::AppRedSocial.Data;
    using global::AppRedSocial.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    namespace AppRedSocial.Controllers
    {
        public class CommentController : Controller
        {
            private readonly AppDbContext _context;

            public CommentController(AppDbContext context)
            {
                _context = context;
            }

          
            public IActionResult List(int postId)
            {
                var comments = _context.Comments
                    .Where(c => c.PostId == postId)
                    .Include(c => c.User)
                    .OrderByDescending(c => c.Id)
                    .ToList();

                ViewBag.PostId = postId;
                return View(comments);
            }

            
            public IActionResult Create(int postId)
            {
                var model = new Comment
                {
                    PostId = postId
                };

                return View(model);
            }

            
            [HttpPost]
            public IActionResult Create(Comment model)
            {
                if (!ModelState.IsValid)
                    return View(model);

                _context.Comments.Add(model);
                _context.SaveChanges();

                return RedirectToAction("List", new { postId = model.PostId });
            }

            
            public IActionResult Edit(int id)
            {
                var comment = _context.Comments.Find(id);

                if (comment == null)
                    return NotFound();

                return View(comment);
            }

           
            [HttpPost]
            public IActionResult Edit(Comment model)
            {
                if (!ModelState.IsValid)
                    return View(model);

                _context.Comments.Update(model);
                _context.SaveChanges();

                return RedirectToAction("List", new { postId = model.PostId });
            }

            
            public IActionResult Delete(int id)
            {
                var comment = _context.Comments
                    .Include(c => c.User)
                    .FirstOrDefault(c => c.Id == id);

                if (comment == null)
                    return NotFound();

                return View(comment);
            }

            
            [HttpPost, ActionName("Delete")]
            public IActionResult DeleteConfirmed(int id)
            {
                var comment = _context.Comments.Find(id);

                if (comment == null)
                    return NotFound();

                int postId = comment.PostId;

                _context.Comments.Remove(comment);
                _context.SaveChanges();

                return RedirectToAction("List", new { postId = postId });
            }
        }
    }

}
