using api.Data;
using api.DTO;
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
                if (_contextAccessor.HttpContext.Items["AuthenticatedUser"] is not AuthenticatedUser)
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "Could not retrieve that user");
                }

                if(await IsIntacctIDInUse(payload.AccountingID))
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "Intacct Id is aleady accesss");
                }

                //sdls
                //cancellation is used to cancel the request if the application is closed freeing up some space
                var sdlQuery = await _context.SolutionDeliveryLeaders.Where(sdl => sdl.SolutionDeliveryLeaderID == payload.SolutionDeliveryLeaderID)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                if(sdlQuery == null)
                {
                    return Result.Failed(HttpStatusCode.BadRequest, "SQL does not exist or you don't have permission to access it");
                }

                var locationQuery = await _context.ResourceLocations.Where(rl => rl.ResourceLocationID == payload.ResourceLocationID)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                if(locationQuery == null)
                {
                    Result.Failed
                }
            }

            catch(Exception ex)
            {

            }
        }

        public async Task<bool> IsIntacctIDInUse(string accountingID)
        {
            return !string.IsNullOrEmpty(accountingID) && await _context.Resources.AnyAsync(pr => pr.AccountingID == accountingID);
        }
    }
}
