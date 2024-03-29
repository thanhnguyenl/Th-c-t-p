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
using Microsoft.AspNetCore.Authorization;


namespace Doan.Controllers
{   
    public class HomeController : Controller
    {       
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        void GetInfo()
        {
            // Lấy thông tin đăng nhập
            if (HttpContext.Session.GetString("taikhoan") != "")
            {
                ViewBag.taikhoan = _context.Cskcb.FirstOrDefault(k => k.TaiKhoan == HttpContext.Session.GetString("taikhoan"));
            }
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            GetInfo();
            return View(await _context.Cskcb.ToListAsync());
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
            HttpContext.Session.SetString("taikhoan", "");
            GetInfo();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        
        public IActionResult Login(string taikhoan, string matkhau)
        {
            var tk = _context.Cskcb.FirstOrDefault(k => k.TaiKhoan == taikhoan);
            if (tk != null && matkhau == tk.MatKhau)
            {
                HttpContext.Session.SetString("taikhoan", taikhoan);
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
