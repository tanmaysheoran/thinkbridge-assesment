using Management.Contracts.Interface;
using Management.DBContext;
using Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Services
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Team> GetTeamAsync(int teamId)
        {
            return  await _context.Teams.Include(t => t.TeamMembers).Include(t => t.Tasks).FirstOrDefaultAsync(t => t.TeamId == teamId);
        }

        public async Task<Team> CreateTeamAsync(string teamName, string teamDescription)
        {
            var team = new Team
            {
                TeamName = teamName,
                Description = teamDescription,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<Team> UpdateTeamAsync(int teamId, string teamName, string teamDescription)
        {
            var team = await _context.Teams.FindAsync(teamId);
            if (team == null)
            {
                return null;
            }

            team.TeamName = teamName;
            team.Description = teamDescription;
            team.UpdatedAt = DateTime.UtcNow;

            _context.Teams.Update(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<Team> DeleteTeamAsync(int teamId)
        {
            var team = await _context.Teams.FindAsync(teamId);
            if (team == null)
            {
                return null;
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return team;
        }
    }

}
