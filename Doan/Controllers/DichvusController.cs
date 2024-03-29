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
    public class DichvusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DichvusController(ApplicationDbContext context)
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

        // GET: Dichvus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dichvu.Include(d => d.MaCskcbNavigation);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dichvus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichvu = await _context.Dichvu
                .Include(d => d.MaCskcbNavigation)
                .FirstOrDefaultAsync(m => m.Stt == id);
            if (dichvu == null)
            {
                return NotFound();
            }
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(dichvu);
        }

        // GET: Dichvus/Create
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

        // POST: Dichvus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Stt,MaDichVu,TenDichVu,DonGia,QuyTrinh,CskcbCgkt,CskcbCls,Id,MaCskcb")] Dichvu dichvu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dichvu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", dichvu.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(dichvu);
        }

        // GET: Dichvus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichvu = await _context.Dichvu.FindAsync(id);
            if (dichvu == null)
            {
                return NotFound();
            }
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", dichvu.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(dichvu);
        }

        // POST: Dichvus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Stt,MaDichVu,TenDichVu,DonGia,QuyTrinh,CskcbCgkt,CskcbCls,Id,MaCskcb")] Dichvu dichvu)
        {
            if (id != dichvu.Stt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dichvu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DichvuExists(dichvu.Stt))
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
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", dichvu.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(dichvu);
        }

        // GET: Dichvus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichvu = await _context.Dichvu
                .Include(d => d.MaCskcbNavigation)
                .FirstOrDefaultAsync(m => m.Stt == id);
            if (dichvu == null)
            {
                return NotFound();
            }
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(dichvu);
        }

        // POST: Dichvus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dichvu = await _context.Dichvu.FindAsync(id);
            _context.Dichvu.Remove(dichvu);
            await _context.SaveChangesAsync();
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DichvuExists(int id)
        {
            GetInfo();
            return _context.Dichvu.Any(e => e.Stt == id);
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

        public async Task<IActionResult> DichvusByKeyWord(string keyword)
        {
            // lấy ds sp thuộc hãng
            var Dichvus = _context.Dichvu.Where(p => p.TenDichVu.Contains(keyword));
            // chuyển qua view
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(await Dichvus.ToListAsync());
        }
    }
}
