using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using api.Models.Roles;

namespace api.Models;

public class User
{
    public long ID { get; set; }
    public Guid UserID { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsSDL { get; set; }
    public string PasswordHash { get; set; }
    public string? ResetToken { get; set; }
    public DateTime? ResetDTMExpiry { get; set; }
    public string? ActivationToken { get; set; }
    public DateTime? ActivationDate { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public DateTime CreatedDTM { get; set; }
    public long UserRoleID { get; set; }
    public bool IsDeleted { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime? DeletedDTM { get; set; }

    [Timestamp]
    public virtual byte[]? RowVersion { get; set; }
    public List<UserSolutionDeliveryLeader>? UserSolutionDeliveryLeaders { get; set; }
    public UserRole UserRole { get; set; }
    public UserPreference? UserPreference { get; set; }
    public List<RefreshToken>? RefreshTokens { get; set; }

    public long? ResourceID { get; set; }
    public Resource? Resource { get; set; }

}