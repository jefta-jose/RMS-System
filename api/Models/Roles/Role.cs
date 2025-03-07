namespace api.Models.Roles
{
    public class Role : BaseRole
    {
        public int Id { get; set; }

        public string Slug { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; } = "ACTIVE";
    }
}
