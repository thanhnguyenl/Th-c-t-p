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
    public class TaikhoansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaikhoansController(ApplicationDbContext context)
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

        // GET: Taikhoans
        public async Task<IActionResult> Index()
        {
            GetInfo();
            // chuyen ve login
            if (ViewBag.taikhoanqt == null)
            {
                return Redirect("~/Homes/KhongCoQuyen");
            }
            return View(await _context.Cskcb.ToListAsync());
        }

        // GET: Taikhoans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cskcb = await _context.Cskcb
                .FirstOrDefaultAsync(m => m.MaCskcb == id);
            if (cskcb == null)
            {
                return NotFound();
            }
            GetInfo();
            if (ViewBag.taikhoanqt == null)
            {
                return Redirect("~/Homes/KhongCoQuyen");
            }
            return View(cskcb);
        }

        // GET: Taikhoans/Create
        public IActionResult Create()
        {
            GetInfo();
            if (ViewBag.taikhoanqt == null)
            {
                return Redirect("~/Homes/KhongCoQuyen");
            }
            return View();
        }

        // POST: Taikhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCskcb,Stt,TaiKhoan,MatKhau")] Cskcb cskcb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cskcb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            GetInfo();
            if (ViewBag.taikhoanqt == null)
            {
                return Redirect("~/Homes/KhongCoQuyen");
            }
            return View(cskcb);
        }

        // GET: Taikhoans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cskcb = await _context.Cskcb.FindAsync(id);
            if (cskcb == null)
            {
                return NotFound();
            }
            GetInfo();
            if (ViewBag.taikhoanqt == null)
            {
                return Redirect("~/Homes/KhongCoQuyen");
            }
            return View(cskcb);
        }

        // POST: Taikhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCskcb,Stt,TaiKhoan,MatKhau")] Cskcb cskcb)
        {
            if (id != cskcb.MaCskcb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cskcb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CskcbExists(cskcb.MaCskcb))
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
            GetInfo();
            if (ViewBag.taikhoanqt == null)
            {
                return Redirect("~/Homes/KhongCoQuyen");
            }
            return View(cskcb);
        }

        // GET: Taikhoans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cskcb = await _context.Cskcb
                .FirstOrDefaultAsync(m => m.MaCskcb == id);
            if (cskcb == null)
            {
                return NotFound();
            }
            GetInfo();
            if (ViewBag.taikhoanqt == null)
            {
                return Redirect("~/Homes/KhongCoQuyen");
            }
            return View(cskcb);
        }

        // POST: Taikhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cskcb = await _context.Cskcb.FindAsync(id);
            _context.Cskcb.Remove(cskcb);
            await _context.SaveChangesAsync();
            GetInfo();
            if (ViewBag.taikhoanqt == null)
            {
                return Redirect("~/Homes/KhongCoQuyen");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CskcbExists(string id)
        {
            GetInfo();
            return _context.Cskcb.Any(e => e.MaCskcb == id);
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
        public async Task<IActionResult> TaikhoansByKeyWord(string keyword)
        {
            // lấy ds sp thuộc hãng
            var Taikhoans = _context.Cskcb.Where(p => p.TaiKhoan.Contains(keyword));
            // chuyển qua view
            return View(await Taikhoans.ToListAsync());
        }
    }
}
