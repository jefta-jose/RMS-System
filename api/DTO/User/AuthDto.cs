namespace api.DTO.User
{
    public class AuthDto : TokenDto
    {
        public string Email { get; set; }

        public string Name { get; set; }
        public long? SdlID { get; set; }

        public Role.RoleDto Role { get; set; }
    }
}
