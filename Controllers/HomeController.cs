using BTL_NMCNPM.Data;
using BTL_NMCNPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTL_NMCNPM.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> JobList(string search = "")
        {
            var jobs = await _context.tblThongTinTuyenDung
                .Where(j => j.sVitri.Contains(search) || string.IsNullOrEmpty(search))
                .ToListAsync();
            
            ViewBag.Search = search;
            return View(jobs);
        }

        public async Task<IActionResult> JobDetail(string id)
        {
            var job = await _context.tblThongTinTuyenDung.FirstOrDefaultAsync(j => j.sMaTD == id);
            return View(job);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public async Task<IActionResult> HoSoUngVien()
        {
            string maNV = HttpContext.Session.GetString("MaNV");
            if (string.IsNullOrEmpty(maNV)) return RedirectToAction("Login", "User");

            var hoSo = await _context.tblHoSoNhanVien.FirstOrDefaultAsync(h => h.sMaNV == maNV);
            return View(hoSo);
        }

        [HttpPost]
        public async Task<IActionResult> HoSoUngVien(tblHoSoNhanVien hoSoNV)
        {
            string maNV = HttpContext.Session.GetString("MaNV");
            string maTK = HttpContext.Session.GetString("MaTK");
            
            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(maTK)) return RedirectToAction("Login", "User");
            
            _context.tblHoSoNhanVien.Add(hoSoNV);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditHoSo(string id)
        {
            var hoSo = await _context.tblHoSoNhanVien.FindAsync(id);
            return View(hoSo);
        }

        [HttpPost]
        public async Task<IActionResult> EditHoSo(tblHoSoNhanVien hoSoUpdate, int id)
        {
            var hoSo = await _context.tblHoSoNhanVien.FindAsync(id);
            if (hoSo != null)
            {
                hoSo.sTenNV = hoSoUpdate.sTenNV;
                hoSo.sEmail = hoSoUpdate.sEmail;
                hoSo.iCCCD = hoSoUpdate.iCCCD;
                hoSo.dNgaysinh = hoSoUpdate.dNgaysinh;
                hoSo.iSDT = hoSoUpdate.iSDT;
                hoSo.sDiachi = hoSoUpdate.sDiachi;
                hoSo.sHocvan = hoSoUpdate.sHocvan;
                hoSo.sKinhnghiem = hoSoUpdate.sKinhnghiem;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("HoSoUngVien");
        }

        [HttpGet]
        public async Task<IActionResult> ThemDanhSachUngTuyen(string sMaTD)
        {
            string maNV = HttpContext.Session.GetString("MaNV");
            if (string.IsNullOrEmpty(maNV)) return RedirectToAction("Contact");

            var danhSachUngTuyen = new tblDanhSachUngTuyen { sMaTD = sMaTD, sMaNV = maNV };
            _context.tblDanhSachUngTuyen.Add(danhSachUngTuyen);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Thongbao()
        {
            string maNV = HttpContext.Session.GetString("MaNV");
            if (string.IsNullOrEmpty(maNV)) return RedirectToAction("Login", "User");
            
            var thongBaoList = await _context.tblThongBao.Where(t => t.sMaNV == maNV).ToListAsync();
            return View(thongBaoList);
        }
    }
}
