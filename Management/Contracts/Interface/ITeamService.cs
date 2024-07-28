using Management.Models;

namespace Management.Contracts.Interface
{
    public interface ITeamService
    {
        Task<Team> GetTeamAsync(int teamId);
        Task<Team> CreateTeamAsync(string teamName, string teamDescription);
        Task<Team> UpdateTeamAsync(int teamId, string teamName, string teamDescription);
        Task<Team> DeleteTeamAsync(int teamId);
    }
}
