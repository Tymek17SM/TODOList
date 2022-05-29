using System;
using System.Collections;
using System.Collections.Generic;
using WebAPI.Filters;
using WebAPI.Wrappers;

namespace WebAPI.Helpers
{
    public static class PaginationHelper
    {
        public static PageResponse<IEnumerable<T>> CreatePageResponse<T>(IEnumerable<T> data, 
            PaginationFilter paginationFilter, int totalRecords)
        {
            var response = new PageResponse<IEnumerable<T>>(data, paginationFilter.PageNumber, paginationFilter.PageSize);

            var totalPages = ((double)totalRecords/(double)paginationFilter.PageSize);
            var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            var currentPage = paginationFilter.PageNumber;

            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;
            response.NextPage = currentPage < roundedTotalPages ? true : false;
            response.PreviousPage = currentPage > 1 ? true : false;

            return response;
        }
    }
}
