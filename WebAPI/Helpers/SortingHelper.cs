using System.Collections.Generic;

namespace WebAPI.Helpers
{
    public class SortingHelper
    {
        public static KeyValuePair<string, string>[] GetSortFields()
        {
            return new[] { SortFields.Title, SortFields.Content, SortFields.DeadLine };
        }
    }

    public class SortFields
    {
        public static KeyValuePair<string, string> Title = new KeyValuePair<string, string>("title", "Title"); 
        public static KeyValuePair<string, string> Content = new KeyValuePair<string, string>("description", "Description"); 
        public static KeyValuePair<string, string> DeadLine = new KeyValuePair<string, string>("deadline", "DeadLine"); 
    }
}
