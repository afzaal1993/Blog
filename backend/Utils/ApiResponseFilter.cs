using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend.Utils
{
    public class ApiResponseFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Check if the result is a simple message (string)
            if (context.Result is ObjectResult objectResult)
            {
                var apiResponse = new ApiResponse<object>
                {
                    Success = objectResult.StatusCode >= 200 && objectResult.StatusCode < 300,
                    Data = objectResult.Value is string ? null : objectResult.Value, // Don't set Data if the value is a string message
                    Message = objectResult.Value is string message ? message : (objectResult.StatusCode >= 200 && objectResult.StatusCode < 300 ? "Request successful" : "An error occurred"),
                    Errors = new List<string>()
                };

                if (!apiResponse.Success && objectResult.Value is SerializableError errors)
                {
                    foreach (var error in errors)
                    {
                        apiResponse.Errors.Add($"{error.Key}: {string.Join(". ", error.Value)}");
                    }
                }

                context.Result = new ObjectResult(apiResponse)
                {
                    StatusCode = objectResult.StatusCode
                };
            }
            else if (context.Result is StatusCodeResult statusCodeResult)
            {
                var apiResponse = new ApiResponse<object>
                {
                    Success = statusCodeResult.StatusCode >= 200 && statusCodeResult.StatusCode < 300,
                    Message = statusCodeResult.StatusCode >= 200 && statusCodeResult.StatusCode < 300 ? "Request successful" : "An error occurred",
                    Errors = new List<string>()
                };

                context.Result = new ObjectResult(apiResponse)
                {
                    StatusCode = statusCodeResult.StatusCode
                };
            }
            base.OnActionExecuted(context);
        }
    }
}
