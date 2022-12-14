using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dietitianwebsite.Data;
using Dietitianwebsite.Models;
using Microsoft.AspNetCore.Identity;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.Security.Permissions;
using System.Drawing;

namespace Dietitianwebsite.Controllers
{
    public class ProgramdietsController : Controller
    {

        public Cloudinary cloudinary;
        public const string CLOUD_NAME = "danduomvk";
        public const string API_KEY = "431785418629677";
         public const string API_SECRET = "NotLAFwy3Cs2G4g4URnZ_OI9wPw";
        //public string imagePath = "C:\\Users\\GeorgesKfoury\\Desktop\\New folder\\Group 4095.png";
        private readonly ApplicationDbContext _context;
        public string link, publicid;

        public void cloudinaryStorage(string imagePath)
        {
            Account account =  new Account(CLOUD_NAME,API_KEY,API_SECRET);
            cloudinary = new Cloudinary(account);
            uploadImage(imagePath);
        }
        public void uploadImage(string path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path),
            };
            var res=cloudinary.Upload(uploadParams);
            publicid = res.PublicId.ToString();
            link = res.Uri.ToString();

        }
        public ActionResult btnchoose_click(Image imagemodel)
        {
            string fileName = imagemodel.ToString();
            System.Diagnostics.Debug.WriteLine(fileName);

            return View();
        }

        public UserManager<IdentityUser> UserManager { get; set; }

        public ProgramdietsController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            UserManager = userManager;

            _context = context;
        }

        // GET: Programdiets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Program;
            return View(await applicationDbContext.ToListAsync());
        }

       

        // GET: Programdiets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Program == null)
            {
                return NotFound();
            }

            var programdiet = await _context.Program
                
                .FirstOrDefaultAsync(m => m.ProgramId == id);
            if (programdiet == null)
            {
                return NotFound();
            }

            return View(programdiet);
        }

        // GET: Programdiets/Create
        public IActionResult Create()
        {
            ViewData["userid"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: Programdiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramId,Name,type,description,image,breakfast,lunch,dinner")] Programdiet programdiet)
        {
            cloudinaryStorage(programdiet.image);
            System.Diagnostics.Debug.WriteLine(programdiet.Name);

            Programdiet p1 = new Programdiet();
            p1.userid = UserManager.GetUserId(HttpContext.User);
            p1.ProgramId = programdiet.ProgramId;
            p1.Name = programdiet.Name;
            p1.type = programdiet.type;
            p1.description = programdiet.description;
            p1.image = link;
            p1.breakfast = programdiet.breakfast;
            p1.lunch = programdiet.lunch;

            p1.dinner = programdiet.dinner;


            _context.Add(p1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(programdiet);
        }

        // GET: Programdiets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Program == null)
            {
                return NotFound();
            }

            var programdiet = await _context.Program.FindAsync(id);
            if (programdiet == null)
            {
                return NotFound();
            }
            return View(programdiet);
        }

        // POST: Programdiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramId,Name,type,description,image,breakfast,lunch,dinner")] Programdiet programdiet)
        {
           
               
                    cloudinaryStorage(programdiet.image);
                    System.Diagnostics.Debug.WriteLine(programdiet.Name);

                    Programdiet p1 = new Programdiet();
                    p1.userid = UserManager.GetUserId(HttpContext.User);
                    p1.ProgramId = programdiet.ProgramId;
                    p1.Name = programdiet.Name;
                    p1.type = programdiet.type;
                    p1.description = programdiet.description;
                    p1.image = link;
                    p1.breakfast = programdiet.breakfast;
                    p1.lunch = programdiet.lunch;

                    p1.dinner = programdiet.dinner;



                    _context.Update(p1);
                    await _context.SaveChangesAsync();
                
               
                return RedirectToAction(nameof(Index));
            
            return View(programdiet);
        }

        // GET: Programdiets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Program == null)
            {
                return NotFound();
            }

            var programdiet = await _context.Program
               
                .FirstOrDefaultAsync(m => m.ProgramId == id);
            if (programdiet == null)
            {
                return NotFound();
            }

            return View(programdiet);
        }

        // POST: Programdiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Program == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Program'  is null.");
            }
            var programdiet = await _context.Program.FindAsync(id);
            if (programdiet != null)
            {
                _context.Program.Remove(programdiet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramdietExists(int id)
        {
          return _context.Program.Any(e => e.ProgramId == id);
        }


    }
}
