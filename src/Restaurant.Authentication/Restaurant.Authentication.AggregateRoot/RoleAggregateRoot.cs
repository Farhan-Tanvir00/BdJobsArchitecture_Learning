using Restaurant.Authentication.DTO.Entity;

namespace Restaurant.Authentication.AggregateRoot
{
    public class RoleAggregateRoot : BaseEntity
    {
        public required string Name { get; set; }
        public string? CreatedBy { get; set; }
        public List<UserAggregateRoot> Users { get; set; } = new List<UserAggregateRoot>();
    }
}
