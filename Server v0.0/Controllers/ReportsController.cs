using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;
using System.Threading.Tasks;

namespace Server_v0._0.Controllers
{
    public class ReportsController : Controller
    {
        private ApplicationContext db;
        public ReportsController(ApplicationContext context)
        {
            db = context;
        }

        //индексация
        public async Task<IActionResult> Index()
        {
            return View(await db.Reports.ToListAsync());
        }

        //создание элемента
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Report user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(user);
            }
            db.Reports.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //подробности
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Report user = await db.Reports.FirstOrDefaultAsync(p => p.ReportId == id);
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
                Report user = await db.Reports.FirstOrDefaultAsync(p => p.ReportId == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Report user, int? id)
        {
            user.ReportId = (int)id;
            if (!this.ModelState.IsValid)
            {
                return this.View(user);
            }
            db.Reports.Update(user);
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
                Report user = await db.Reports.FirstOrDefaultAsync(p => p.ReportId == id);
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
                Report user = await db.Reports.FirstOrDefaultAsync(p => p.ReportId == id);
                user.IsDeleted = !user.IsDeleted;
                db.Reports.Update(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
