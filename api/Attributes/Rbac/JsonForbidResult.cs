using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace api.Attributes.Rbac
{
    public interface JsonForbidResult : IActionResult
    {
        //This code defines a custom IActionResult implementation called JsonForbidResult that returns a JSON response
        //with a 403 Forbidden status code. This is typically used in ASP.NET Core applications to handle authorization
        //failures in a more user-friendly way, by returning a structured JSON response instead of a plain text or HTML response.
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
