using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Person : Auditable
    {
        [Key]
        [Column("PERSON_ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("LAST_NAME")]
        public string LastName { get; set; }

        [Column("BIRTHDAY")]
        public DateTime Birthday { get; set; }
    }
}