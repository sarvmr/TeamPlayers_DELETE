using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamPlayer.Data;
using TeamPlayer.Models;

namespace TeamPlayer.Pages_PlayerPages
{
    public class IndexModel : PageModel
    {
        private readonly TeamPlayer.Data.ApplicationDbContext _context;

        public IndexModel(TeamPlayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Players != null)
            {
                Player = await _context.Players
                .Include(p => p.Team).ToListAsync();
            }
        }
    }
}
