using System.ComponentModel.DataAnnotations.Schema;

namespace RestNet5Api.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id {get; set;}
    }
}