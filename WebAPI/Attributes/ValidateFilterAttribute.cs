using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Helpers;
using WebAPI.Wrappers;

namespace WebAPI.Attributes
{
    public class ValidateFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            if (!context.ModelState.IsValid)
            {
                var errors = AttributeHelper.GetErrorList(context);

                var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

                context.Result = new BadRequestObjectResult(new Response<bool>
                {
                    Succeeded = false,
                    Message = "Something went wrong.",
                    Errors = errors
                });

                logger.Warn($"Validation has failed.\nValidation error list:\n{errors.CreateString()}");
            }
        }
    }
}
