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
        [BindProperty(SupportsGet = true)]
        public string SearchPlayer { get; set; }
        public Player Player { get; set; }
        private LeagueContext _context;

        public IndexModel(LeagueContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Players = await _context.Players.ToListAsync();
            var players = from c in _context.Players
                            select c;

            if (!string.IsNullOrEmpty(SearchPlayer))
            {

                players = players.Where(x => x.Name.Contains(SearchPlayer));
            }
                Players = await players.ToListAsync();
        }

    }
}
