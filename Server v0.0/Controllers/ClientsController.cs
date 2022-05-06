using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;
using System.Threading.Tasks;

namespace Server_v0._0.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationContext db;
        public ClientsController(ApplicationContext context)
        {
            db = context;
        }

        //индексация
        public async Task<IActionResult> Index()
        {
            return View(await db.Clients.ToListAsync());
        }

        //создание элемента
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Client user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(user);
            }
            db.Clients.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //подробности
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Client user = await db.Clients.FirstOrDefaultAsync(p => p.ClientId == id);
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
                Client user = await db.Clients.FirstOrDefaultAsync(p => p.ClientId == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Client user, int? id)
        {
            user.ClientId = (int)id;
            if (!this.ModelState.IsValid)
            {
                return this.View(user);
            }
            db.Clients.Update(user);
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
                Client user = await db.Clients.FirstOrDefaultAsync(p => p.ClientId == id);
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
                Client user = await db.Clients.FirstOrDefaultAsync(p => p.ClientId == id);
                user.IsDeleted = !user.IsDeleted;
                db.Clients.Update(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
