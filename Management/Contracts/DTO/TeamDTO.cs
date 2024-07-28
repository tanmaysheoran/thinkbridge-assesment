namespace Management.Contracts.DTO
{
    public class CreateTeamRequest
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
    }

    public class UpdateTeamRequest
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
    }
}
