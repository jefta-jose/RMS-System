using System;
using System.Collections.Generic;

namespace api.DTO.User;

public class UserDto
{
    public long ID { get; set; }
    public Guid UserID { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsSDL { get; set; }
    public bool IsActive { get; set; }
    public string PasswordHash { get; set; }

    public string? ResetToken { get; set; }
    public DateTime? ResetDTMExpiry { get; set; }
    public string? ActivationToken { get; set; }
    public DateTime? ActivationDate { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public DateTime CreatedDTM { get; set; }
    public long? ResourceID { get; set; }
    public bool IsDeleted { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime? DeletedDTM { get; set; }
    
    public int RoleId { get; set; }
    public Role.RoleDto Role { get; set; }
    public string? Token { get; set; }
    public IEnumerable<UserSolutionDeliveryLeaderDto>? SolutionDeliveryLeaders { get; set; }
}