using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamPlayer.Data;
using TeamPlayer.Models;

namespace TeamPlayer.Pages_PlayerPages
{
    public class CreateModel : PageModel
    {
        private readonly TeamPlayer.Data.ApplicationDbContext _context;

        public CreateModel(TeamPlayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TeamName"] = new SelectList(_context.Teams, "TeamName", "TeamName");
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Players == null || Player == null)
            {
                return Page();
            }

            _context.Players.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
