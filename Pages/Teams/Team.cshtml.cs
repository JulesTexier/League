using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using League.Data;
using League.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueTeam
{
    public class TeamModel : PageModel
    {
        private readonly LeagueContext _context;
        public Team team { get; set; }

        public TeamModel (LeagueContext context)
        {
            _context = context;

        }


        public async Task OnGetAsync(string id)
        {
            team = await _context.Teams.FindAsync(id);
        }
    }
}
