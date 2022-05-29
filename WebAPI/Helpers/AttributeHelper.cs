using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Helpers
{
    public static class AttributeHelper
    {
        public static IEnumerable<string> GetErrorList(ResultExecutingContext context)
        {
            var errorList = new List<string>();

            var entries = context.ModelState.Values;

            foreach (var error in entries)
            {
                errorList.AddRange(error.Errors.Select(e => e.ErrorMessage));
            }

            return errorList;
        }

        public static string CreateString(this IEnumerable<string> list)
        {
            var result = string.Empty;
            foreach(var error in list)
            {
                result += $"- {error}\n";
            }
            return result;
        }
    }
}
