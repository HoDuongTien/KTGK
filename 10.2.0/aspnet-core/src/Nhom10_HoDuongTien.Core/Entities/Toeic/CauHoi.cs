using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Abp.Domain.Entities;

namespace Nhom10_HoDuongTien.Core.Entities.Toeic
{
    public class CauHoi : Entity<int>
    {
        [Required]
        public int PhanThiId { get; set; }

        public int? DoanVanId { get; set; }

        [Required]
        public int SoCauHoi { get; set; }

        [Required]
        public string NoiDungCauHoi { get; set; }

        [ForeignKey("PhanThiId")]
        public virtual PhanThi PhanThi { get; set; }

        [ForeignKey("DoanVanId")]
        public virtual DoanVan DoanVan { get; set; }

        public virtual ICollection<LuaChon> LuaChons { get; set; }
    }
}