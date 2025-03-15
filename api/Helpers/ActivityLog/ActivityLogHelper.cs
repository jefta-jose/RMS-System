using api.Data;
using api.DTO.ActivityLog;
using api.DTO.User;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using static api.Helpers.AuthenticatedHelper;

namespace api.Helpers.ActivityLog
{
    public class ActivityLogHelper
    {
        public static void AddActivityLog(ActivityLogDto dto, RmsDbContext context, IHttpContextAccessor _httpContextAccessor)
        {
            //IP Address: RemoteIpAddress helps in security monitoring, fraud detection, or analytics.
            var requestIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();

            //User Agent: Captures browser, OS, and device information.
            var requestUserAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();

            //Referrer: Helps track the origin of the request (e.g., whether a user came from another website).
            var requestReferrer = _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString();

            //Requested URL & Query String: Records the exact action performed, useful for debugging and analytics.
            var requestUrl = _httpContextAccessor.HttpContext.Request.Path.ToString();
            var requestQueryString = _httpContextAccessor.HttpContext.Request.QueryString.ToString();

            // retrieves the logged-in user identity to track who performed an action. if unavailable it defaults to created by or 1 system
            var auth = _httpContextAccessor.HttpContext.Items["authenticatedUser"] as AuthenticatedUser;
            var createdBy = auth?.ID ?? (dto.CreatedBy != 0 ? dto.CreatedBy : 1);

            var actitivityLog = new Models.ActivityLog.ActivityLog
            {
                ActivityType = dto.ActivityType,
                Description = dto.Description,
                OldValue = dto.OldValue,
                NewValue = dto.NewValue,
                IpAddress = requestIpAddress ?? "No Ip Address",
                UserAgent = requestUserAgent,
                Referrer = requestReferrer,
                Url = requestUrl,
                QueryString = requestQueryString,
                RequestBody = dto.RequestBody,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.Now,
            };

            context.ActivityLogs.Add(actitivityLog);
            context.SaveChangesAsync();
        }

        public static void ArchiveLogs(RmsDbContext context)
        {
            var logs = context.ActivityLogs;

            foreach(var log in logs)
            {
                if(log.CreatedAt < DateTime.Now.AddDays(-90))
                {
                    log.IsArchived = true;
                }
            }
        }

        public static ActivityLogDto MapActivityLogToDto(Models.ActivityLog.ActivityLog log)
        {
            return new ActivityLogDto
            {
                Id = log.Id,
                ActivityType = log.ActivityType,
                Description = log.Description,
                OldValue = log.OldValue,
                NewValue = log.NewValue,
                IpAddress = log.IpAddress,
                UserAgent = log.UserAgent,
                Referrer = log.Referrer,
                Url = log.Url,
                QueryString = log.QueryString,
                RequestBody = log.RequestBody,
                IsArchived = log.IsArchived,
                CreatedBy = log.CreatedBy,
                CreatedAt = DateTimeExtensions.GetDateTimeInEst(log.CreatedAt),
                Creator = log.Creator != null ? new UserDto
                {
                    ID = log.Creator.ID,
                    FirstName = log.Creator.FirstName,
                    LastName = log.Creator.LastName,
                } : null
            };
        }
    }
}
