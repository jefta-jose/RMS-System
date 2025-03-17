using api.Data;
using api.DTO;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Linq;
using static api.Helpers.AuthenticatedHelper;
using api.Helpers;

namespace api.CQRS.Resources.Commands
{
    public class UpdateResourceCommand : IRequest<Result>
    {
        public Guid ResourceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AccountingID { get; set; }
        public Guid ResourceTypeId { get; set; }
        public Guid ResourceLevelId { get; set; }
        public Guid ResourceLocationID { get; set; }
        public Guid SolutionDeliveryLeaderID { get; set; }
        public Guid EmployeeTypeID { get; set; }
        public Guid EarningTypeID { get; set; }
        public DateTime StartDTM { get; set; }
        public DateTime? EndDTM { get; set; }
    }

    public class UpdateResourceCommandHandler (IMapper mapper, RmsDbContext context, IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateResourceCommand, Result>
    {
        private readonly IMapper _mapper = mapper;
        private readonly RmsDbContext _context = context;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<Result> Handle(UpdateResourceCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (await isIntacctIdDublicated(request))
                    return Result.Failed(HttpStatusCode.BadRequest, "Intacct Id already exists");

                var existingResource = await _context.Resources.Where(rId => rId.ResourceId == request.ResourceId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (existingResource == null)
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "specified resource not found");
                }

                if (request.EndDTM != null && request.EndDTM <= request.StartDTM)
                    return Result.Failed(HttpStatusCode.BadRequest, "estimated end date is not valid");

                if (_httpContextAccessor.HttpContext?.Items["authenticatedUser"] is not AuthenticatedUser authUser)
                    return Result.Failed(HttpStatusCode.BadRequest, " could not find authneticated");

                var sdlQuery = _context.SolutionDeliveryLeaders.Where(sdl => sdl.SolutionDeliveryLeaderID == request.SolutionDeliveryLeaderID);
                sdlQuery = PermissionHelpers.ApplyLocationFilter(sdlQuery, authUser);

                if (!sdlQuery.Any())
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "sdl does not exist or you don't have permission to access it");
                }

                //resource location
                var locationQuery = _context.ResourceLocations.Where(rL => rL.ResourceLocationID == request.ResourceLocationID);
                locationQuery = PermissionHelpers.ApplyLocationFilter(locationQuery, authUser);

                if (!locationQuery.Any())
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "resource location does not exist or you don't have permission to access it");
                }

                var resourceType = _context.ResourceTypes.Where(rt => rt.ResourceTypeId == request.ResourceTypeId);

                if (!resourceType.Any())
                    return Result.Failed(HttpStatusCode.BadRequest, "Resource type does not exist");

                var resourceLevel = _context.ResourceLevels.Where(rl => rl.ResourceLevelId == request.ResourceLevelId);

                if (!resourceLevel.Any())
                    return Result.Failed(HttpStatusCode.BadRequest, "Resource level does not exist");

                // Validate EmployeeTypeID
                var employeeType = _context.EmployeeTypes
                    .Where(et => et.EmployeeTypeID == request.EmployeeTypeID);

                if (!employeeType.Any())
                    return Result.Failed(HttpStatusCode.BadRequest, "Employee type does not exist");

                // Validate EarningTypeID
                var earningType = _context.EarningTypes
                    .Where(et => et.EarningTypeID == request.EarningTypeID);

                if (!earningType.Any())
                    return Result.Failed(HttpStatusCode.BadRequest, "Earning type does not exist");

                _mapper.Map(request, existingResource);

                existingResource.ResourceTypeId = resourceType.FirstOrDefault()!.ID;
                existingResource.ResourceLevelId = resourceLevel.FirstOrDefault()!.ID;
                existingResource.ResourceLocationID = locationQuery.FirstOrDefault()!.ID;
                existingResource.SolutionDeliveryLeaderID = sdlQuery.FirstOrDefault()!.ID;
                existingResource.EmployeeTypeID = employeeType.FirstOrDefault()!.ID;
                existingResource.EarningTypeID = earningType.FirstOrDefault()!.ID;
                existingResource.UpdatedBy = authUser.ID;

                if (existingResource.User != null)
                {
                    existingResource.User.FirstName = request.FirstName;
                    existingResource.User.LastName = request.LastName;
                    existingResource.User.Email = request.Email;
                    existingResource.User.UserName = request.Email;
                    existingResource.User.FullName = request.FirstName + " " + request.LastName;
                    existingResource.User.UpdatedDTM = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync(cancellationToken);

                return Result.Success(HttpStatusCode.OK, "Resource updated successfully");
            }

            catch(Exception ex)
            {
                return Result.Failed(HttpStatusCode.InternalServerError, $"There was an error processing your request - {ex.Message} - {ex.InnerException.Message} - {ex.StackTrace} ");
            }

        }

        public async Task<bool> isIntacctIdDublicated(UpdateResourceCommand request)
        {
            return !string.IsNullOrEmpty(request.AccountingID) && await _context.Resources.AnyAsync(rId => rId.AccountingID == request.AccountingID && rId.ResourceId != request.ResourceId);
        }
    }
}
