namespace SchoolERPSystem.Test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("schoolclass")]
    public partial class schoolclass
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string ClassName { get; set; }

        public int? SectionId { get; set; }

        public virtual section section { get; set; }
    }
}
