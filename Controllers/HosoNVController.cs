using BTL_NMCNPM.Data;
using BTL_NMCNPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTL_NMCNPM.Controllers
{
    public class HosoNVController : Controller
    {
        private readonly AppDbContext _context;

        public HosoNVController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Danh sách hồ sơ nhân viên
        public async Task<IActionResult> Index()
        {
            var hosoNV = await _context.tblHoSoNhanVien.ToListAsync();
            return View(hosoNV);
        }

        // GET: Trang tạo hồ sơ nhân viên
        public IActionResult TaoHoso()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TaoHoso(tblHoSoNhanVien hosoNV)
        {
            if (ModelState.IsValid)
            {
                _context.tblHoSoNhanVien.Add(hosoNV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hosoNV);
        }

        // GET: Chỉnh sửa hồ sơ nhân viên
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var hosoNV = await _context.tblHoSoNhanVien.FindAsync(id);
            if (hosoNV == null) return NotFound();

            return View(hosoNV);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(tblHoSoNhanVien hsNVupdate)
        {
            if (ModelState.IsValid)
            {
                var hosoNV = await _context.tblHoSoNhanVien.FindAsync(hsNVupdate.sMaNV);
                if (hosoNV == null) return NotFound();

                // Cập nhật thông tin
                hosoNV.sTenNV = hsNVupdate.sTenNV;
                hosoNV.sEmail = hsNVupdate.sEmail;
                hosoNV.iCCCD = hsNVupdate.iCCCD;
                hosoNV.dNgaysinh = hsNVupdate.dNgaysinh;
                hosoNV.iSDT = hsNVupdate.iSDT;
                hosoNV.sDiachi = hsNVupdate.sDiachi;
                hosoNV.sHocvan = hsNVupdate.sHocvan;
                hosoNV.sKinhnghiem = hsNVupdate.sKinhnghiem;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hsNVupdate);
        }

        // GET: Xóa hồ sơ nhân viên
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var hosoNV = await _context.tblHoSoNhanVien.FindAsync(id);
            if (hosoNV == null) return NotFound();

            return View(hosoNV);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hosoNV = await _context.tblHoSoNhanVien.FindAsync(id);
            if (hosoNV != null)
            {
                _context.tblHoSoNhanVien.Remove(hosoNV);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
