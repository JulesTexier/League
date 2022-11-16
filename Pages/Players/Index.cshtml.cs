using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using League.Data;
using League.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlayersIndex
{
    public class IndexModel : PageModel
    {

        public List <Player> Players { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchPlayer { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortField { get; set; } = "Name";
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


            switch(SortField)
            {
                case "Name":
                    players = players.OrderBy(x => x.Name);
                    break;
                case "Rank":
                    players = players.OrderBy(x => x.Rank);
                    break;
                case "Age":
                    players = players.OrderBy(x => x.Age);
                    break;

            }
            
                Players = await players.ToListAsync();
        }



    }
}
