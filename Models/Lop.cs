using System;
using System.Collections.Generic;

namespace WebApplication4.Models;

public partial class Lop
{
    public string MaLop { get; set; } = null!;

    public string? Nganh { get; set; }

    public string? Khoa { get; set; }

    public virtual Khoa? KhoaNavigation { get; set; }

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
