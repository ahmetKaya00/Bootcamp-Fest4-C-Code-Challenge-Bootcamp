using efcoreapp.Data;
using efcoreapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreapp.Controllers
{

    public class BootcampController : Controller
    {

        private readonly DataContext _context;

        public BootcampController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Bootcamps.Include(b => b.Ogretmen).ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BootcampViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Bootcamps.Add(new Bootcamp() { BootcampId = model.BootcampId, Baslik = model.Baslik, OgretmenId = model.OgretmenId });
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var btc = await _context.Bootcamps
            .Include(x => x.KursKayitlari)
            .ThenInclude(x => x.Ogrenci)
            .Select(b => new BootcampViewModel
            {
                BootcampId = b.BootcampId,
                Baslik = b.Baslik,
                OgretmenId = b.OgretmenId,
                KursKayitlari = b.KursKayitlari
            })
            .FirstOrDefaultAsync(o => o.BootcampId == id);


            if (btc == null)
            {
                return NotFound();
            }

            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");

            return View(btc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BootcampViewModel model)
        {
            if (id != model.BootcampId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(new Bootcamp() { BootcampId = model.BootcampId, Baslik = model.Baslik, OgretmenId = model.OgretmenId });
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Bootcamps.Any(o => o.BootcampId == model.BootcampId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Bootcamp = await _context.Bootcamps.FindAsync(id);

            if (Bootcamp == null)
            {
                return NotFound();
            }
            return View(Bootcamp);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var Bootcamp = await _context.Bootcamps.FindAsync(id);
            if (Bootcamp == null)
            {
                return NotFound();
            }
            _context.Bootcamps.Remove(Bootcamp);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}