using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Abp.Domain.Entities;

namespace Nhom10_HoDuongTien.Core.Entities.Toeic
{
    public class LuaChon : Entity<int>
    {
        [Required]
        public int CauHoiId { get; set; }

        [Required]
        [StringLength(1)]
        public string Nhan { get; set; } // A, B, C, D

        [MaxLength(500)]
        public string NoiDung { get; set; }

        public bool LaDapAnDung { get; set; }

        [ForeignKey("CauHoiId")]
        public virtual CauHoi CauHoi { get; set; }
    }
}