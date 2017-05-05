using System.Collections.Generic;

namespace DemoMoq.Library
{
    public class PagedView<T> where T : class
    {
        public string FilterKey { get; set; }
        public int RecordIndex { get; set; }
        public int TotalRecords { get; set; }
        public int? Page { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public string SortDir { get; set; }
        public IEnumerable<T> ResultSet { get; set; }
    }
}
