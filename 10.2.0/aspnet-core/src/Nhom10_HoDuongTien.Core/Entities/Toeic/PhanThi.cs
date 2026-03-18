using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Abp.Domain.Entities;

namespace Nhom10_HoDuongTien.Core.Entities.Toeic
{
    public class PhanThi : Entity<int>
    {
        [Required]
        public int DeThiId { get; set; }

        [Required]
        public int SoPhan { get; set; }

        [ForeignKey("DeThiId")]
        public virtual DeThi DeThi { get; set; }

        public virtual ICollection<DoanVan> DoanVans { get; set; }

        public virtual ICollection<CauHoi> CauHois { get; set; }
    }
}