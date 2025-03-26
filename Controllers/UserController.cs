using BTL_NMCNPM.Data;
using BTL_NMCNPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BTL_NMCNPM.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: User SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ThemTaiKhoan(string name, string taikhoan, string password)
        {
            DateTime currentTime = DateTime.Now;
            string newID = taikhoan + currentTime.Minute.ToString() + currentTime.Second.ToString();

            var tk = new tblTaiKhoan
            {
                sMaTK = newID,
                sMaQuyen = "2",
                sTaiKhoan = taikhoan,
                sMatKhau = password,
                sTinhTrang = "Xem xét"
            };

            _context.tblTaiKhoan.Add(tk);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("user", taikhoan);
            return RedirectToAction("Index", "Home");
        }

        // GET: User Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(string taikhoan, string matkhau)
        {
            var prov = await _context.tblTaiKhoan
                .Where(s => s.sTaiKhoan == taikhoan && s.sMatKhau == matkhau)
                .ToListAsync();

            if (!prov.Any())
            {
                return RedirectToAction("Error404", "Home");
            }

            var user = prov.First();
            HttpContext.Session.SetString("MaquyenUser", user.sMaQuyen);
            HttpContext.Session.SetString("user", user.sTaiKhoan);
            HttpContext.Session.SetString("MaTK", user.sMaTK);

            if (user.sMaQuyen == "1")
            {
                return RedirectToAction("QlyAccount");
            }
            else
            {
                var currentNV = await _context.tblNhanVien
                    .Where(row => row.sMaTK == user.sMaTK)
                    .FirstOrDefaultAsync();

                HttpContext.Session.SetString("MaNV", currentNV?.sMaNV ?? "");
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> QlyAccount()
        {
            var accounts = await _context.tblTaiKhoan.ToListAsync();
            return View(accounts);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CapNhatAccount(string mataikhoan, string taikhoan, string matkhau, string tinhtrang)
        {
            var updateAccount = await _context.tblTaiKhoan.FindAsync(mataikhoan);
            if (updateAccount != null)
            {
                updateAccount.sTaiKhoan = taikhoan;
                updateAccount.sMatKhau = matkhau;
                updateAccount.sTinhTrang = tinhtrang;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("QlyAccount");
        }

        [HttpPost]
        public async Task<IActionResult> XoaAccount(string mataikhoan)
        {
            var deleteTK = await _context.tblTaiKhoan.FindAsync(mataikhoan);
            if (deleteTK != null)
            {
                _context.tblTaiKhoan.Remove(deleteTK);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("QlyAccount");
        }
    }
}
