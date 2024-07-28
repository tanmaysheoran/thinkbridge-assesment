namespace Management.Models
{
    public enum Priority
    {
        Low,
        Medium,
        High,
        Critical
    }

    public enum Status
    {
        New,
        Pending,
        InProgress,
        Completed,
        OnHold
    }

    public enum ActionType
    {
        Create,
        Update,
        Delete,
        Review
    }

}
