using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace api.Attributes.Rbac
{
    public interface JsonForbidResult : IActionResult
    {
        public Task ExecutedResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 403;
            context.HttpContext.Response.ContentType = "application/json";

            var response = new
            {
                Succeeded = false,
                Error = "Forbidden",
                Message = "You do not have the required permission to access this resource"
            };

            return context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
