using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Auditable : EntityBase
    {
        private const int LENGTH = 25;

        [Column("CREATED")]
        public DateTime? Created { get; set; }

        [Column("CREATED_BY")]
        [MaxLength(LENGTH)]
        public string CreatedBy { get; set; }

        [Column("MODIFIED")]
        public DateTime? Modified { get; set; }

        [Column("MODIFIED_BY")]
        [MaxLength(LENGTH)]
        public string ModifiedBy { get; set; }
    }
}