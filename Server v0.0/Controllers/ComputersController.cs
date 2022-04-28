using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;
using System.Threading.Tasks;

namespace Server_v0._0.Controllers
{
    public class ComputersController : Controller
    {
        private ApplicationContext db;
        public ComputersController(ApplicationContext context)
        {
            db = context;
        }

        //индексация
        public async Task<IActionResult> Index()
        {
            return View(await db.Computers.ToListAsync());
        }

        //создание элемента
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Computer user)
        {
            db.Computers.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //подробности
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Computer user = await db.Computers.FirstOrDefaultAsync(p => p.ComputerId == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        //изменить
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Computer user = await db.Computers.FirstOrDefaultAsync(p => p.ComputerId == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Computer user, int? id)
        {
            user.ComputerId = (int)id;
            db.Computers.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //суицид данных
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Computer user = await db.Computers.FirstOrDefaultAsync(p => p.ComputerId == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Computer user = new Computer { ComputerId = id.Value };
                db.Entry(user).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
