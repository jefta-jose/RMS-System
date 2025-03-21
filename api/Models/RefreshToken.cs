﻿using Microsoft.EntityFrameworkCore;
using System;

namespace api.Models
{

    [Owned]
    public class RefreshToken
    {

        public long Id { get; set; }
        public long UserID { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public string ReasonRevoked { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsRevoked => Revoked != null;
        public bool IsActive => !IsRevoked && !IsExpired;

        public virtual byte[] RowVersion { get; set; }
    }
}
