using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Common
{
    public class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        [MaxLength(100)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }

    }
}
