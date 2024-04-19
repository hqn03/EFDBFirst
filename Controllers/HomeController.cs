using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DateOnly test = new DateOnly(2003, 10, 10);
            
            
            DbDbfirstContext db = new DbDbfirstContext();
            var danhsachSinhVien = (from sv in db.SinhViens
                                   join l in db.Lops on sv.Lop equals l.MaLop
                                   join k in db.Khoas on l.Khoa equals k.MaKhoa
                                   where k.TenKhoa == "Công nghệ số" && DateTime.Now.Year - sv.NgaySinh.Value.Year <=20 && DateTime.Now.Year - sv.NgaySinh.Value.Year >= 18
                                    select sv).ToList();
            ViewBag.danhsachsinhvien = danhsachSinhVien;
            return View();
        }
        private int TinhTuoi(DateOnly? ngaySinh)
        {
            DateTime now = DateTime.Now;
            int tuoi = now.Year - ngaySinh.Value.Year;
            if (now.Month <  ngaySinh.Value.Month || (now.Month==ngaySinh.Value.Month && now.Day < ngaySinh.Value.Day))
                tuoi--;
            return tuoi;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
