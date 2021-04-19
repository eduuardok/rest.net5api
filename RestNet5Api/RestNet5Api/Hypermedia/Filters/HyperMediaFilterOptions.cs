using System.Collections.Generic;
using RestNet5Api.Hypermedia.Abstract;

namespace RestNet5Api.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}