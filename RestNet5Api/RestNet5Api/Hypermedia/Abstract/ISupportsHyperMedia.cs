using System.Collections.Generic;

namespace RestNet5Api.Hypermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
         List<HyperMediaLink> Links {get; set;}
    }
}