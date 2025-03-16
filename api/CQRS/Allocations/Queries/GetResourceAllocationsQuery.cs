using api.DTO;
using api.DTO.Allocation;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace api.CQRS.Allocations.Queries
{
    //CQRS -> command query resnponsibility segragation
    
    //query defination
    // this class here acts as a data transfer object for the request
    //it implements IRequest<Result<list<Allocation>>> meaning that its going to retunr a list of allocation dto
    public class GetResourceWeekAllocationsQuery : IRequest<Result<List<AllocationDto>>>
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }
    }

    //query handler implements the IRequestHandler<TRequest , TResponse>
    // method in the class
    // Task<TResposen> Handle (TRequest request, CancellationToken cancellationToken)....
    public class GetResourceWeekAllocationsQueryHandler(IConfiguration configuration) 
        : IRequestHandler<GetResourceWeekAllocationsQuery , Result<List<AllocationDto>>>
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<Result<List<AllocationDto>>> Handle(GetResourceWeekAllocationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var parameters = new
                {
                    resourceID = request.Id,
                    mondayWeekBucket = request.Date
                };

                using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                //execute stored procedure Dashboard_GetResourceWeekAllocationData.sql
                var resourceAllocations = await connection.QueryAsync<AllocationDto>(
                    sql: "Dashboard_GetResourceWeekAllocationData",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );

                return Result<List<AllocationDto>>.Success(HttpStatusCode.OK, [..resourceAllocations]);
            }

            catch(Exception ex)
            {
                return Result<List<AllocationDto>>.Failed(HttpStatusCode.InternalServerError, $"Error: {ex.Message} - {ex.StackTrace} - {ex.InnerException.Message}.");
            }
        }
    }

}
