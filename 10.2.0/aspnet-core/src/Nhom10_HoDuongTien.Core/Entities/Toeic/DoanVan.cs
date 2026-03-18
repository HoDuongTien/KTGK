using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace Nhom10_HoDuongTien.Core.Entities.Toeic;
public class DoanVan
{
    public int Id { get; set; }

    [Required]
    public int PhanThiId { get; set; }

    public string NoiDung { get; set; }

    [ForeignKey("PhanThiId")]
    public PhanThi PhanThi { get; set; }

    public ICollection<CauHoi> CauHois { get; set; }
}