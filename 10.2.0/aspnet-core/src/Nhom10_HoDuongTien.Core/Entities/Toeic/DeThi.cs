using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Abp.Domain.Entities;

namespace Nhom10_HoDuongTien.Core.Entities.Toeic
{
    public class DeThi : Entity<int>
    {
        [Required]
        [MaxLength(200)]
        public string TieuDe { get; set; }

        [Required]
        public int ThoiGianThi { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public virtual ICollection<PhanThi> PhanThis { get; set; }
    }
}