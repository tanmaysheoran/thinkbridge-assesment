using Management.Contracts.Interface;
using Management.Models;

namespace Management.Services
{
    public class EmunService : IEmunService
    {
        public List<string> GetPriorityItems()
        {
            return Enum.GetNames(typeof(Priority)).ToList();
        }

        public List<string> GetStatusItems()
        {
            return Enum.GetNames(typeof(Status)).ToList();
        }

        public List<string> GetActionTypeItems()
        {
            return Enum.GetNames(typeof(ActionType)).ToList();
        }
    }
}
