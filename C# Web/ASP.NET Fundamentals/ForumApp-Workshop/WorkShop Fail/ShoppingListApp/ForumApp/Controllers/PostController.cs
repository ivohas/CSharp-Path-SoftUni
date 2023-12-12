using ForumApp.Data;
using ForumApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext _data;
        public PostController(ForumAppDbContext data)
        {
            _data = data;
        }

        public async Task<IActionResult> All()
        {
            var post = await _data
                .Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();
            return View(post);
        }
    }
}
