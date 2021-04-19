using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RestNet5Api.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}