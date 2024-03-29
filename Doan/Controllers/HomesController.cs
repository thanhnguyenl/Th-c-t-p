using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Doan.Data;
using Doan.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace Doan.Controllers
{
    public class HomesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        void GetInfo()
        {
            // Lấy thông tin đăng nhập
            if (HttpContext.Session.GetString("taikhoanqt") != "")
            {
                ViewBag.taikhoanqt = _context.Taikhoanquantri.FirstOrDefault(k => k.TaiKhoan == HttpContext.Session.GetString("taikhoanqt"));
            }
        }

        // GET: Homes
        public async Task<IActionResult> Index()
        {
            GetInfo();
            return View(await _context.Taikhoanquantri.ToListAsync());
        }

        public IActionResult Login()
        {
            GetInfo();
            return View();
        }
        public IActionResult Customer()
        {
            GetInfo();
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("taikhoanqt", "");
            GetInfo();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Login(string taikhoan, string matkhau)
        {
            var tk = _context.Taikhoanquantri.FirstOrDefault(k => k.TaiKhoan == taikhoan);
            if (tk != null && matkhau == tk.MatKhau)
            {
                HttpContext.Session.SetString("taikhoanqt", taikhoan);
                return RedirectToAction(nameof(Customer));
            }
            // chuyen ve login
            return RedirectToAction(nameof(Login));
        }

        public IActionResult KhongCoQuyen()
        {
            GetInfo();
            return View();
        }
    }
}
