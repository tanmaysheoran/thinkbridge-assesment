using Management.Models;

namespace Management.Contracts.Interface
{
    public interface IEmunService
    {
        List<string> GetPriorityItems();
        List<string> GetStatusItems();
        List<string> GetActionTypeItems();
    }
}
