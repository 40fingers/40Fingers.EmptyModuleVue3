using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FortyFingers.EmptyModuleVue3.Services.ViewModels
{
    // https://datatables.net/forums/discussion/40690/sample-implementation-of-serverside-processing-in-c-mvc-ef-with-paging-sorting-searching
    public class DatatablesProcessingModel
    {
        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }
    }

    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }
    }

    public class Search
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }

    public class DatatableProcessingResultModel<T>
    {
        [JsonProperty("draw")]
        public int Draw { get; set; }
        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }
        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
