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
    public class VattusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VattusController(ApplicationDbContext context)
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
        // GET: Vattus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vattu.Include(v => v.MaCskcbNavigation);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vattus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vattu = await _context.Vattu
                .Include(v => v.MaCskcbNavigation)
                .FirstOrDefaultAsync(m => m.Stt == id);
            if (vattu == null)
            {
                return NotFound();
            }
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(vattu);
        }

        // GET: Vattus/Create
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

        // POST: Vattus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Stt,MaVatTu,NhomVatTu,TenVatTu,MaHieu,QuyCach,HangSx,NuocSx,DonViTinh,DonGia,DonGiaBh,TyleTtBh,SoLuong,DanhMuc,NhaThau,TtThau,TuNgay,DenNgay,MaCskcb,LoaiThau,HtThau,Id")] Vattu vattu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vattu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", vattu.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(vattu);
        }

        // GET: Vattus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vattu = await _context.Vattu.FindAsync(id);
            if (vattu == null)
            {
                return NotFound();
            }
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", vattu.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(vattu);
        }

        // POST: Vattus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Stt,MaVatTu,NhomVatTu,TenVatTu,MaHieu,QuyCach,HangSx,NuocSx,DonViTinh,DonGia,DonGiaBh,TyleTtBh,SoLuong,DanhMuc,NhaThau,TtThau,TuNgay,DenNgay,MaCskcb,LoaiThau,HtThau,Id")] Vattu vattu)
        {
            if (id != vattu.Stt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vattu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VattuExists(vattu.Stt))
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
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", vattu.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(vattu);
        }

        // GET: Vattus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vattu = await _context.Vattu
                .Include(v => v.MaCskcbNavigation)
                .FirstOrDefaultAsync(m => m.Stt == id);
            if (vattu == null)
            {
                return NotFound();
            }
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(vattu);
        }

        // POST: Vattus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vattu = await _context.Vattu.FindAsync(id);
            _context.Vattu.Remove(vattu);
            await _context.SaveChangesAsync();
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool VattuExists(int id)
        {
            GetInfo();
            return _context.Vattu.Any(e => e.Stt == id);
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

        public async Task<IActionResult> VattusByKeyWord(string keyword)
        {
            // lấy ds sp thuộc hãng
            var Vattus = _context.Vattu.Where(p => p.TenVatTu.Contains(keyword));
            // chuyển qua view
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(await Vattus.ToListAsync());
        }
    }
}
