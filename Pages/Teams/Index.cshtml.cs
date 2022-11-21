using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using League.Models;
using League.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;

namespace LeagueIndexTeam
{
	public class IndexTeamModel : PageModel
    {
        private readonly LeagueContext _context;
        public List<Player> Players;
        public List<Team> Teams { get; set; }
        public List<Division> Divisions { get; set; }
        public List<Conference>Conferences { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FavoriteTeam { get; set; }
        public string test { get; set; }
        public string SessionKeyName = "_Favorite";



        public IndexTeamModel(LeagueContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Divisions = await _context.Divisions.ToListAsync();
            Conferences = await _context.Conferences.ToListAsync();
            Teams = await _context.Teams.ToListAsync();

            var teams = from t in Teams
                        orderby t.Win descending
                        select t;



            if(FavoriteTeam != null)
            {
              HttpContext.Session.SetString("_Favorite", FavoriteTeam);
            }
            else
            {
                FavoriteTeam = HttpContext.Session.GetString("_Favorite");
            }
        }

        public List<Team> getDivisionTeams(string divisionId)
        {
            return Teams.Where(t => t.DivisionId == divisionId).OrderByDescending(t => t.Win).ToList();

        }


        public List<Division> getConferenceDivisions(string ConferenceId)
        {
            return Divisions.Where(d => d.ConferenceId == ConferenceId).ToList();
        }


    }
}
