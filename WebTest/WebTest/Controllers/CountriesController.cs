using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class CountriesController : Controller
    {
        /*private readonly WebTestContext _context;*/
        private SkiContext db = new SkiContext();

        /*public CountriesController(WebTestContext context)
        {
            _context = context;
        }*/
        public CountriesController(SkiContext _db)
        {
            db = _db;
            var sitesList = new List<Site>
            {
                new Site { Name = "AA", Rank = 3, Location = "Ohio", Pistes = 234, Difficulty = 6, BeerPrice = 16.5, SeasonStart = new DateTime(2008, 3, 9, 16, 5, 7, 123), SeasonEnd = new DateTime(2018, 10, 15, 16, 5, 7, 123), CountryID=1},
                new Site { Name = "AA", Rank = 3, Location = "Hawaii", Pistes = 3, Difficulty = 2, BeerPrice = 12.5, SeasonStart = new DateTime(2008, 4, 8, 16, 5, 7, 123), SeasonEnd = new DateTime(2018, 5, 5, 16, 5, 7, 123), CountryID=1},
                new Site { Name = "BB", Rank = 5, Location = "New York", Pistes = 100, Difficulty = 3, BeerPrice = 10, SeasonStart = new DateTime(2008, 5, 7, 16, 5, 7, 123), SeasonEnd = new DateTime(2018, 8, 8, 16, 5, 7, 123), CountryID=1},
                new Site { Name = "CC", Rank = 2, Location = "Florida", Pistes = 53, Difficulty = 7, BeerPrice = 20, SeasonStart = new DateTime(2008, 6, 10, 16, 5, 7, 123), SeasonEnd = new DateTime(2018, 10, 15, 16, 5, 7, 123), CountryID=2},
                new Site { Name = "DD", Rank = 7, Location = "Texas", Pistes = 8, Difficulty = 8, BeerPrice = 19.2, SeasonStart = new DateTime(2008, 2, 4, 16, 5, 7, 123), SeasonEnd = new DateTime(2018, 6, 7, 16, 5, 7, 123), CountryID=2},
                new Site { Name = "EE", Rank = 8, Location = "Utah", Pistes = 90, Difficulty = 3, BeerPrice = 5, SeasonStart = new DateTime(2008, 3, 3, 16, 5, 7, 123), SeasonEnd = new DateTime(2018, 5, 15, 16, 5, 7, 123), CountryID=3},
                new Site { Name = "FF", Rank = 6, Location = "California", Pistes = 167, Difficulty = 5, BeerPrice = 7.5, SeasonStart = new DateTime(2008, 5, 9, 16, 5, 7, 123), SeasonEnd = new DateTime(2018, 6, 15, 16, 5, 7, 123), CountryID=4},
            };
            sitesList.ForEach(s => db.Sites.Add(s));
            db.SaveChanges();
            var countriesList = new List<Country>
            {
                new Country { Name = "United State", Language = "English", Currency = "USD"},
                new Country { Name = "Israel", Language = "Hebrew", Currency = "ILS"},
                new Country { Name = "France", Language = "French", Currency = "EUR"},
                new Country { Name = "United State", Language = "English", Currency = "GBP"},
            };
            countriesList.ForEach(c => db.Countries.Add(c));
            db.SaveChanges();
        }

        /*
        // GET: Countries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Country.ToListAsync());
        }
        */

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            return View(await db.Countries.ToListAsync());
        }

        /*
        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .FirstOrDefaultAsync(m => m.CountryID == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }
        */

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await db.Countries
                .FirstOrDefaultAsync(m => m.CountryID == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }


        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        /*
        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryID,Name,Language,Currency")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }
        */

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryID,Name,Language,Currency")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Add(country);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        /*
        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }
        */

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await db.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        /*
        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryID,Name,Language,Currency")] Country country)
        {
            if (id != country.CountryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryID))
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
            return View(country);
        }
        */

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryID,Name,Language,Currency")] Country country)
        {
            if (id != country.CountryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(country);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryID))
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
            return View(country);
        }

        /*
        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .FirstOrDefaultAsync(m => m.CountryID == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }
        */

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await db.Countries
                .FirstOrDefaultAsync(m => m.CountryID == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        /*
        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _context.Country.FindAsync(id);
            _context.Country.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await db.Countries.FindAsync(id);
            db.Countries.Remove(country);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /*
        private bool CountryExists(int id)
        {
            return _context.Country.Any(e => e.CountryID == id);
        }
        */
        
        private bool CountryExists(int id)
        {
            return db.Countries.Any(e => e.CountryID == id);
        }
    }
}
