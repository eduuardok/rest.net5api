using System.Collections.Generic;

namespace RestNet5Api.Data.Converter.Contract
{
    public interface IParser<O, D>
    {
         D Parse(O origin);
         List<D> Parse(List<O> origin);
    }
}