using api.Data;
using api.DTO;
using api.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static api.Helpers.AuthenticatedHelper;

namespace api.CQRS.Resources.Commands
{
    //syntax -> public class ClassName : IRequest<returns?>
    public class AddResourceCommand : IRequest<Result>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid ResourceTypeId { get; set; }
        public Guid ResourceLevelId { get; set; }
        public Guid ResourceLocationID { get; set; }
        public Guid SolutionDeliveryLeaderID { get; set; }
        public Guid EmployeeTypeID { get; set; }
        public Guid EarningTypeID { get; set; }
        public DateTime StartDTM { get; set; }
        public DateTime? EndDTM { get; set; }
        public string AccountingID { get; set; }
    }

    public class AddResourceCommandHandler(IMapper mapper, RmsDbContext context, IHttpContextAccessor contextAccessor) : IRequestHandler<AddResourceCommand, Result>
    {
        private readonly IMapper _mapper = mapper;
        private readonly RmsDbContext _context = context;
        private readonly IHttpContextAccessor _contextAccessor = contextAccessor;

        public async Task<Result> Handle(AddResourceCommand payload, CancellationToken cancellationToken)
        {
            try
            {
                if (_contextAccessor.HttpContext.Items["AuthenticatedUser"] is not AuthenticatedUser user)
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "Could not retrieve that user");
                }

                if(await IsIntacctIDInUse(payload.AccountingID))
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "Intacct Id is aleady in use");
                }

                //sdls
                //cancellation is used to cancel the request if the application is closed freeing up some space
                var sdlQuery = await _context.SolutionDeliveryLeaders.Where(sdl => sdl.SolutionDeliveryLeaderID == payload.SolutionDeliveryLeaderID)
                    .FirstOrDefaultAsync(cancellationToken);

                if(sdlQuery == null)
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "SQL does not exist or you don't have permission to access it");
                }

                var locationQuery = await _context.ResourceLocations.Where(rl => rl.ResourceLocationID == payload.ResourceLocationID)
                    .FirstOrDefaultAsync(cancellationToken);

                if(locationQuery == null)
                {
                    Result.Failed(HttpStatusCode.BadRequest, "resource location  does not exist or you don't have access to that resource");
                }

                if(await _context.Resources.AnyAsync(x => x.Email == payload.Email, cancellationToken))
                {
                    return Result.Failed(HttpStatusCode.BadRequest, $"a resource with email address {payload.Email} already exists");
                }

                if(payload.EndDTM <= payload.StartDTM && payload.EndDTM != null)
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "estimated end date is not valid");
                }

                var resourceLevel = await _context.ResourceLevels.Where(rL => rL.ResourceLevelId == payload.ResourceLevelId)
                    .FirstOrDefaultAsync(cancellationToken);

                if(resourceLevel == null)
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "resource level does not exist");
                }

                var resourceType = await _context.ResourceTypes.Where(rT => rT.ResourceTypeId == payload.ResourceTypeId)
                    .FirstOrDefaultAsync(cancellationToken);

                if(resourceType == null)
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "resource type does not exist");
                }

                //validate EmployeeId
                var employeeType = await _context.EmployeeTypes.Where(eT => eT.EmployeeTypeID == payload.EmployeeTypeID)
                    .FirstOrDefaultAsync(cancellationToken);

                if(employeeType == null)
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "employee type does not exists");
                }

                //validate earning type
                var earningType = await _context.EarningTypes.Where(earningT => earningT.EarningTypeID == payload.EarningTypeID)
                    .FirstOrDefaultAsync(cancellationToken);

                if(earningType == null)
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "earning type does not exist");
                }

                var newResource = _mapper.Map<Resource>(payload);

                newResource.ResourceLevelId = resourceLevel.ID;
                newResource.ResourceLevelId = resourceLevel.ID;
                newResource.ResourceLocationID = locationQuery.ID;
                newResource.SolutionDeliveryLeaderID = sdlQuery.ID;
                newResource.EmployeeTypeID = employeeType.ID;
                newResource.EarningTypeID = earningType.ID;
                newResource.CreatedBy = user.ID;
                newResource.IsActive = true;

                await _context.AddAsync(newResource, cancellationToken);
                await _context.SaveChangesAsync();

                return Result.Success(HttpStatusCode.OK, "resource created successfully");
            }

            catch(Exception ex)
            {
                return Result.Failed(HttpStatusCode.InternalServerError, $"Error Creating resource{ex.Message} - {ex.InnerException.Message} - {ex.StackTrace}");
            }
        }

        public async Task<bool> IsIntacctIDInUse(string accountingID)
        {
            return !string.IsNullOrEmpty(accountingID) && await _context.Resources.AnyAsync(pr => pr.AccountingID == accountingID);
        }
    }
}
