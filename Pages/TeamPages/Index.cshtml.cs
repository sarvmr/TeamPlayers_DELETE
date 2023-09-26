using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamPlayer.Data;
using TeamPlayer.Models;

namespace TeamPlayer.Pages_TeamPages
{
    public class IndexModel : PageModel
    {
        private readonly TeamPlayer.Data.ApplicationDbContext _context;

        public IndexModel(TeamPlayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Teams != null)
            {
                Team = await _context.Teams.ToListAsync();
            }
        }
    }
}
