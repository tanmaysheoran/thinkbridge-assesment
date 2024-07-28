namespace Management.Contracts.DTO
{

    public class CreateRoleRequest
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
    }

    public class UpdateRoleRequest
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
