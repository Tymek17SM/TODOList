using System.Linq;
using WebAPI.Helpers;

namespace WebAPI.Filters
{
    public class SortingFilter
    {
        public string SortField { get; set; }
        public bool Ascending { get; set; } = true;

        public SortingFilter()
        {
            SortField = "Id";
        }

        public SortingFilter(string sortField, bool ascending)
        {
            var sortFields = SortingHelper.GetSortFields();

            sortField = sortField.ToLower();

            if (sortFields.Select(k => k.Key).Contains(sortField))
                sortField = sortFields.Where(k => k.Key == sortField).Select(k => k.Value).SingleOrDefault();
            else
                sortField = "Id";

            SortField = sortField;
            Ascending = ascending;
        }
    }
}
