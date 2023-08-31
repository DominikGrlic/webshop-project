using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_shop.Data;
using web_shop.Models;

namespace web_shop.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly AppDbContex _context;

        public ProductsController(AppDbContex context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
              return _context.Products != null ? 
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'AppDbContex.Products'  is null.");
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewBag.ErrorMsg = TempData["ErrorMsg"] as string ?? "";
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Sku,Title,Description,InStock,Price,Image")] Product product,
            int[] categoryIds,
            IFormFile Image
            )
        {
            // 1. korak --->provjeri ako je "categoryIds" prazan ili nula
            if(categoryIds.Length == 0 || categoryIds == null)
            {
                // izbaci poruku kako se kategorije moraju odabrati
                // tempData ---> kolekcija koja kreira kratkorocne poruke u sesiji izmedu dvije akcije
                TempData["ErrorMsg"] = "Odaberite minimalno jednu kategorij!";
                return RedirectToAction(nameof(Create));
            }    

            // 2. korak ---> pohrani proizvod u tablicu i nakon toga povezi proizvod s odabranim kategorijama
            if (ModelState.IsValid)
            {
                // 2.1 korak ---> pokusaj pohraniti sliku na disk i spremni naziv slike u svojstvo "product.Image"
                try
                {
                    // primjer 1
                    var imageName = Image.FileName.ToLower();

                    // primjer 2
                    // bez razmaka i doljnjih crta
                    //var imageName = Image.FileName.ToLower().Replace(" ", "-").Replace("_", "-");

                    // primjer 3
                    //var getFileExtension = Path.GetExtension(Image.FileName);
                    //var imageName = DateTime.Now.ToString("yyyy-mm-dd-hh-mm-ss") + getFileExtension;



                    // Odabir putanje gdje ce slika biti pohranjena
                    // Rezultat: ~/wwwroot/images/products/naziv-slike.jpg
                    var saveImagePath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/images/products",
                            imageName
                        );

                    // kreiraj direktorije i poddirektorije unutar zadane putanje (wwwroot/images/products)
                    Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));

                    // ovdje se datoteka fizicki kopira unutar zadane putanje (wwwroot/images/products) direktorija projekta
                    using (var stream = new FileStream(saveImagePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }

                    // u stupac tablice pohranjujemo samo naziv datoteke
                    product.Image = imageName;
                  
                }
                catch (Exception ex)
                {
                    TempData["ErrorMsg"] = ex.Message;
                    return RedirectToAction(nameof(Create));
                }

                _context.Add(product);
                await _context.SaveChangesAsync();

                // nakon pohrane zapisa u tablicu EF CORE ce u objekt popuniti vrijednost za svojstvo product.Id

                // 2.2 korak ---> povezi product.Id sa stavkama niza categoryIds i pohrani sve u tablicu ProductCategories
                foreach(var categoryId in categoryIds)
                {
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.CategoryId = categoryId;
                    productCategory.ProductId = product.Id;

                    _context.ProductCategories.Add(productCategory);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // dohvati ID-eve kategorija s kojima je proizvod povezan u tablici ProductCategories
            ViewBag.ProdCategories = _context.ProductCategories.Where(p => p.ProductId == product.Id).Select(c => c.CategoryId).ToList();

            ViewBag.ErrorMsg = TempData["ErrorMsg"] as string ?? "";

            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, 
            [Bind("Id,Sku,Title,Description,InStock,Price,Image")] Product product, 
            IFormFile? newImage,
            int[] categoryIds
            )
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            
            // provjeri ako je odabrana barem jedna kategorija
            if(categoryIds.Length == 0)
            {
                TempData["ErrorMsg"] = "Molim odaberite barem jednu kategoriju!";
                return RedirectToAction(nameof(Edit), new { id = id });
            }

            if (ModelState.IsValid)
            {
                try
                {

                    // provjeri postoji li vrijednost parametra newImage (netko je dodao sliku)
                    if(newImage != null) 
                    {
                        var newImageName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_" + newImage.FileName.ToLower().Replace(" ", "_");

                        // Odabir putanje gdje ce slika biti pohranjena
                        // Rezultat: ~/wwwroot/images/products/naziv-slike.jpg
                        var saveImagePath = Path.Combine(
                                Directory.GetCurrentDirectory(),
                                "wwwroot/images/products",
                                newImageName
                            );

                        // kreiraj direktorije i poddirektorije unutar zadane putanje (wwwroot/images/products)
                        Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));

                        // ovdje se datoteka fizicki kopira unutar zadane putanje (wwwroot/images/products) direktorija projekta
                        using (var stream = new FileStream(saveImagePath, FileMode.Create))
                        {
                            newImage.CopyTo(stream);
                        }

                        // u stupac tablice pohranjujemo samo naziv datoteke
                        product.Image = newImageName;
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();

                    // azuriramo kategorije proizvoda u tablici ProductCategories

                    // 1. izbrisi sve postojece konekcije izmedu kategorije i proizvoda (ako postoje)
                    _context.ProductCategories.RemoveRange(_context.ProductCategories.Where(p => p.ProductId == id));
                    _context.SaveChanges();

                    // azuriraj nove podatke s vezom izmedu proizvoda i kategorije u tablici ProductCategories
                    foreach(var category in categoryIds)
                    {
                        ProductCategory productCategory = new ProductCategory();
                        productCategory.ProductId = id;
                        productCategory.CategoryId = category;
                        _context.Add(productCategory);
                    }

                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AppDbContex.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
