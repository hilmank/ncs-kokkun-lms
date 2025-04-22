namespace KokkunLMS.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public required string RoleName { get; set; }

        public List<User>? Users { get; set; }
    }
}
