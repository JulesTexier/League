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
        public List<Division> Divisions { get; set; }
        public List<Conference>Conferences { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedTeam { get; set; }
        public Team FavoriteTeam { get; set; }


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
