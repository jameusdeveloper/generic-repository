using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Country : Auditable
    {
        [Key]
        [Column("COUNTRY_ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
    }
}