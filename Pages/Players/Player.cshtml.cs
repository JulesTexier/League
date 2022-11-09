using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using League.Models;
using League.Data;

namespace LeaguePlayers
{
    public class PlayerModel : PageModel
    {
        public readonly LeagueContext _context;
        public Player player;

        public PlayerModel(LeagueContext context)
        {
           _context = context;
        }

        public async Task OnGetAsync(string id)
        {
            player = await _context.Players.FindAsync(id);
        }
    }
}
