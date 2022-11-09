using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using League.Data;
using League.Models;
using Microsoft.EntityFrameworkCore;

namespace PlayersIndex
{
    public class IndexModel : PageModel
    {

        public List <Player> Players { get; set; }
        private LeagueContext _context;

        public IndexModel(LeagueContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Players = await _context.Players.ToListAsync();
        }
    }
}
