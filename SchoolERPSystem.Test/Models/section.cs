namespace SchoolERPSystem.Test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("section")]
    public partial class section
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public section()
        {
            schoolclasses = new HashSet<schoolclass>();
        }

        public int Id { get; set; }

        [StringLength(150)]
        public string SectionName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<schoolclass> schoolclasses { get; set; }
    }
}
