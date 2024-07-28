using Management.Models;

namespace Management.Contracts.Interface
{
    public interface ITeamMemeberService
    {
        Task<List<TeamMember>> GetTeamMembersByTeamIdAsync(int teamId);
        Task<bool> AddTeamMemberAsync(int teamId, int userId, bool isManager);
        Task<bool> RemoveTeamMemberAsync(int teamId, int userId);
    }
}
