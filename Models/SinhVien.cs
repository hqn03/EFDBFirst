using System;
using System.Collections.Generic;

namespace WebApplication4.Models;

public partial class SinhVien
{
    public string MaSinhVien { get; set; } = null!;

    public string? HoTen { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? Lop { get; set; }

    public virtual Lop? LopNavigation { get; set; }

    private int TinhTuoi(DateOnly? ngaySinh)
    {
        int tuoi = DateTime.Now.Year - ngaySinh.Value.Year;
        if (DateTime.Now.DayOfYear > ngaySinh.Value.DayOfYear)
            tuoi--;
        return tuoi;
    }
}
