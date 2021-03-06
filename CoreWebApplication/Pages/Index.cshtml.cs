using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreWebApplication.Pages.UserList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_db.User.Any(o => o.Phone == User.Phone))
                    return BadRequest("Phone Already Exists");

                await _db.User.AddAsync(User);
                await _db.SaveChangesAsync();
                return RedirectToPage("UserList");
            }
            else
            {
                return Page();
            }
        }
    }
}
