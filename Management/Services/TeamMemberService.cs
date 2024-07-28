using Management.Contracts.Interface;
using Management.DBContext;
using Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Services
{
    public class TeamMemberService : ITeamMemeberService
    {
        private readonly ApplicationDbContext _context;

        public TeamMemberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeamMember>> GetTeamMembersByTeamIdAsync(int teamId)
        {
            return await _context.TeamMembers
                .Where(tm => tm.TeamId == teamId)
                .ToListAsync();
        }

        public async Task<bool> AddTeamMemberAsync(int teamId, int userId, bool isManager)
        {
            var teamMember = new TeamMember
            {
                TeamId = teamId,
                UserId = userId,
                IsManager = isManager
            };

            _context.TeamMembers.Add(teamMember);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveTeamMemberAsync(int teamId, int userId)
        {
            var teamMember = await _context.TeamMembers
                .FirstOrDefaultAsync(tm => tm.TeamId == teamId && tm.UserId == userId);

            if (teamMember == null)
            {
                return false;
            }

            _context.TeamMembers.Remove(teamMember);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
