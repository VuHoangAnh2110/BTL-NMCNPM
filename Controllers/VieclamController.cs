using BTL_NMCNPM.Data;
using BTL_NMCNPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BTL_NMCNPM.Controllers
{
    public class VieclamController : Controller
    {
        private readonly AppDbContext _context;

        public VieclamController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AdminQlyViecLam(string search = "")
        {
            var jobs = await _context.tblThongTinTuyenDung
                .Where(j => j.sVitri.Contains(search))
                .ToListAsync();
            ViewBag.search = search;
            return View(jobs);
        }

        public IActionResult CreateVieclam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVieclam(tblThongTinTuyenDung CreateTuyendung)
        {
            if (ModelState.IsValid)
            {
                await _context.tblThongTinTuyenDung.AddAsync(CreateTuyendung);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Thêm tin tuyển dụng thành công!";
                return RedirectToAction("AdminQlyViecLam");
            }
            return View(CreateTuyendung);
        }

        public async Task<IActionResult> EditViecLam(string id)
        {
            var job = await _context.tblThongTinTuyenDung.FindAsync(id);
            if (job == null) return NotFound();
            return View(job);
        }

        [HttpPost]
        public async Task<IActionResult> EditViecLam(tblThongTinTuyenDung tuyendungupdate)
        {
            if (ModelState.IsValid)
            {
                _context.tblThongTinTuyenDung.Update(tuyendungupdate);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Cập nhật tin tuyển dụng thành công!";
                return RedirectToAction("AdminQlyViecLam");
            }
            return View(tuyendungupdate);
        }

        public async Task<IActionResult> DeleteViecLam(string id)
        {
            var job = await _context.tblThongTinTuyenDung.FindAsync(id);
            if (job == null) return NotFound();
            return View(job);
        }

        [HttpPost, ActionName("DeleteViecLam")]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            var job = await _context.tblThongTinTuyenDung.FindAsync(id);
            if (job != null)
            {
                _context.tblThongTinTuyenDung.Remove(job);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Xóa tin tuyển dụng thành công!";
            }
            return RedirectToAction("AdminQlyViecLam");
        }

        public async Task<IActionResult> DanhSachUngTuyen(string sMaTD)
        {
            var applicants = await _context.tblDanhSachUngTuyen
                .Where(a => a.sMaTD == sMaTD)
                .Select(a => _context.tblHoSoNhanVien.FirstOrDefault(hs => hs.sMaNV == a.sMaNV))
                .Where(hs => hs != null)
                .ToListAsync();

            return View(applicants);
        }

        public IActionResult Guithongbao(string sMaNV)
        {
            ViewBag.maNV = sMaNV;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Guithongbao(tblThongBao thongBao)
        {
            if (ModelState.IsValid)
            {
                await _context.tblThongBao.AddAsync(thongBao);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Gửi thông báo thành công!";
                return RedirectToAction("AdminQlyViecLam");
            }
            return View(thongBao);
        }
    }
}
