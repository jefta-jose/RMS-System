namespace api.DTO.User;

public class ChangePasswordResult
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
    public string StatusCode { get; set; }
}