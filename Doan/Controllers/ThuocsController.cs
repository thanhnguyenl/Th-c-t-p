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
using Microsoft.AspNetCore.Authorization;

namespace Doan.Controllers
{
    public class ThuocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThuocsController(ApplicationDbContext context)
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

        
        // GET: Thuocs
        public async Task<IActionResult> Index()
        {
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            var applicationDbContext = _context.Thuoc.Include(t => t.MaCskcbNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Thuocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuoc = await _context.Thuoc
                .Include(t => t.MaCskcbNavigation)
                .FirstOrDefaultAsync(m => m.Stt == id);
            if (thuoc == null)
            {
                return NotFound();
            }
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(thuoc);
        }

        // GET: Thuocs/Create
        public IActionResult Create()
        {
            GetInfo();
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb");
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View();
        }

        // POST: Thuocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Stt,MaThuoc,TenHoatChat,TenThuoc,DonViTinh,HamLuong,DuongLuong,MaDuongLuong,DangBaoChe,SoDangKy,SoLuong,DonGia,DonGiaBh,QuyCach,NhaSx,NuocSx,NhaThau,TtThau,TuNgay,DenNgay,MaCskcb,LoaiThuoc,LoaiThau,HtThau,MaDvkt,Tccl,BoPhanVt,TenKhoaHoc,NguonGoc,PpChebien,MaDlNhap,MaDlCb,MaTlhhCb,TlhhBq,Id")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", thuoc.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(thuoc);
        }

        // GET: Thuocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuoc = await _context.Thuoc.FindAsync(id);
            if (thuoc == null)
            {
                return NotFound();
            }
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", thuoc.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(thuoc);
        }

        // POST: Thuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Stt,MaThuoc,TenHoatChat,TenThuoc,DonViTinh,HamLuong,DuongLuong,MaDuongLuong,DangBaoChe,SoDangKy,SoLuong,DonGia,DonGiaBh,QuyCach,NhaSx,NuocSx,NhaThau,TtThau,TuNgay,DenNgay,MaCskcb,LoaiThuoc,LoaiThau,HtThau,MaDvkt,Tccl,BoPhanVt,TenKhoaHoc,NguonGoc,PpChebien,MaDlNhap,MaDlCb,MaTlhhCb,TlhhBq,Id")] Thuoc thuoc)
        {
            if (id != thuoc.Stt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuocExists(thuoc.Stt))
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
            ViewData["MaCskcb"] = new SelectList(_context.Cskcb, "MaCskcb", "MaCskcb", thuoc.MaCskcb);
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(thuoc);
        }

        // GET: Thuocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuoc = await _context.Thuoc
                .Include(t => t.MaCskcbNavigation)
                .FirstOrDefaultAsync(m => m.Stt == id);
            if (thuoc == null)
            {
                return NotFound();
            }
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return View(thuoc);
        }

        // POST: Thuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuoc = await _context.Thuoc.FindAsync(id);
            _context.Thuoc.Remove(thuoc);
            await _context.SaveChangesAsync();
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ThuocExists(int id)
        {
            GetInfo();
            return _context.Thuoc.Any(e => e.Stt == id);
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

        public async Task<IActionResult> ThuocsByKeyWord(string keyword)
        {
            // lấy ds sp thuộc hãng
            var Thuocs = _context.Thuoc.Where(p => p.TenThuoc.Contains(keyword));
            GetInfo();
            if (ViewBag.taikhoan == null)
            {
                return Redirect("~/Home/KhongCoQuyen");
            }
            // chuyển qua view
            return View(await Thuocs.ToListAsync());
        }
    }
}
