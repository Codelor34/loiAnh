using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tesst.Models;

namespace tesst.Controllers
{
    public class SanPhamController : Controller
    {
        AppDbContext _context;
        public SanPhamController()
        {
            _context = new AppDbContext();
        }
        // GET: SanPhamController
        public ActionResult Index()
        {
            var sp = _context.sanPhams.ToList();
            return View(sp);
        }

        // GET: SanPhamController/Details/5
        public ActionResult Details(Guid id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var sp = _context.sanPhams.Find(id);
            if(sp == null)
            {
                return NotFound();
            }
            return View();
        }

        // GET: SanPhamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPhamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPham sp, IFormFile imgfile) // la mot interface dai dien cho cac file dc upload
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","IMG",imgfile.Name);
            var stream = new FileStream(path, FileMode.Create);
            imgfile.CopyTo(stream);
            sp.ImgUrl = imgfile.FileName;
            _context.sanPhams.Add(sp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: SanPhamController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var sanpham = _context.sanPhams.Find(id);
            return View(sanpham);
        }

        // POST: SanPhamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, SanPham sanpham, IFormFile imgfile)
        {
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "IMG", imgfile.Name);
            //var stream = new FileStream(path, FileMode.Create);
            //imgfile.CopyTo(stream);
            //sanpham.ImgUrl = imgfile.FileName;
            _context.sanPhams.Update(sanpham);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: SanPhamController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var sanpham = _context.sanPhams.Find(id);
            return View(sanpham);
        }

        // POST: SanPhamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SanPham sanPham)
        {
            _context.sanPhams.Remove(sanPham);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
