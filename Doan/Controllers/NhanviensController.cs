using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Doan.Data;
using Doan.Models;
using Microsoft.AspNetCore.Http;

namespace Doan.Controllers
{
    public class NhanviensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhanviensController(ApplicationDbContext context)
        {
            _context = context;
        }

        void GetInfo()
        {
            // Lấy thông tin đăng nhập
            if (HttpContext.Session.GetString("taikhoan") != "")
            {
                ViewBag.taikhoan = _context.Cskcb.FirstOrDefault(k => k.MaCskcb == HttpContext.Session.GetString("taikhoan"));
                ViewBag.taikhoan = _context.Cskcb.FirstOrDefault(k => k.TaiKhoan == HttpContext.Session.GetString("taikhoan"));
            }
        }
       
        // GET: Nhanviens
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Nhanvien.Include(n => n.MaCskcbNavigation);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nhanviens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .Include(n => n.MaCskcbNavigation)
                .FirstOrDefaultAsync(m => m.Stt == id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(nhanvien);
        }

        // GET: Nhanviens/Create
        public IActionResult Create()
        {
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb");
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View();
        }

        // POST: Nhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Stt,MaLoaiKcb,MaKhoa,MaBhxh,HoTen,Macchn,MaCskcb")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", nhanvien.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(nhanvien);
        }

        // GET: Nhanviens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", nhanvien.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(nhanvien);
        }

        // POST: Nhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Stt,MaLoaiKcb,MaKhoa,MaBhxh,HoTen,Macchn,MaCskcb")] Nhanvien nhanvien)
        {
            if (id != nhanvien.Stt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.Stt))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", nhanvien.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(nhanvien);
        }

        // GET: Nhanviens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .Include(n => n.MaCskcbNavigation)
                .FirstOrDefaultAsync(m => m.Stt == id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(nhanvien);
        }

        // POST: Nhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanvien = await _context.Nhanvien.FindAsync(id);
            _context.Nhanvien.Remove(nhanvien);
            await _context.SaveChangesAsync();
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(int id)
        {
            GetInfo();
            return _context.Nhanvien.Any(e => e.Stt == id);
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

        public async Task<IActionResult> NhanviensByKeyWord(string keyword)
        {
            // lấy ds sp thuộc hãng
            var Nhanviens = _context.Nhanvien.Where(p => p.HoTen.Contains(keyword));
            // chuyển qua view
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(await Nhanviens.ToListAsync());
        }
    }
}
