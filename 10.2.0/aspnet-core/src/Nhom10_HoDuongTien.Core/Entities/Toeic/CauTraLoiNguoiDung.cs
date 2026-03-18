using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace Nhom10_HoDuongTien.Core.Entities.Toeic;
public class CauTraLoiNguoiDung
{
    public int Id { get; set; }

    [Required]
    public int CauHoiId { get; set; }

    [Required]
    public int LuaChonId { get; set; }

    public long UserId { get; set; }

    [ForeignKey("CauHoiId")]
    public CauHoi CauHoi { get; set; }

    [ForeignKey("LuaChonId")]
    public LuaChon LuaChon { get; set; }
}