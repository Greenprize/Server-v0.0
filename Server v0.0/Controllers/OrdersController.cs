using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;
using System.Threading.Tasks;

namespace Server_v0._0.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationContext db;
        public OrdersController(ApplicationContext context)
        {
            db = context;
        }

        //индексация
        public async Task<IActionResult> Index()
        {
            return View(await db.Orders.ToListAsync());
        }

        //создание элемента
        public IActionResult Create()
        {
            var clients = db.Clients.AsNoTracking();

            ViewBag.Clients = new SelectList(clients, nameof(Client.ClientId), nameof(Client.Name));

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Order user)
        {
            db.Orders.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //подробности
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Order user = await db.Orders.FirstOrDefaultAsync(p => p.OrderId == id);
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
                Order user = await db.Orders.FirstOrDefaultAsync(p => p.OrderId == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Order user, int? id)
        {
            user.OrderId = (int)id;
            db.Orders.Update(user);
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
                Order user = await db.Orders.FirstOrDefaultAsync(p => p.OrderId == id);
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
                Order user = new Order { OrderId = id.Value };
                db.Entry(user).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
