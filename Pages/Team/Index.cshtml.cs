using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using League.Data;
using League.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueIndexTeam
{
	public class IndexTeamModel : PageModel
    {
        private readonly LeagueContext _context;
        public List<Player> Players;
        public List<Team> Teams { get; set; }

        public IndexTeamModel(LeagueContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Teams = await _context.Teams.ToListAsync();
        }
    }
}
