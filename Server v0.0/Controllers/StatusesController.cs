﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;
using System.Threading.Tasks;

namespace Server_v0._0.Controllers
{
    public class StatusesController : Controller
    {
        private ApplicationContext db;
        public StatusesController(ApplicationContext context)
        {
            db = context;
        }

        //индексация
        public async Task<IActionResult> Index()
        {
            return View(await db.Statuses.ToListAsync());
        }

        //создание элемента
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Status user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(user);
            }
            db.Statuses.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //подробности
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Status user = await db.Statuses.FirstOrDefaultAsync(p => p.StatusId == id);
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
                Status user = await db.Statuses.FirstOrDefaultAsync(p => p.StatusId == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Status user, int? id)
        {
            user.StatusId = (int)id;
            if (!this.ModelState.IsValid)
            {
                return this.View(user);
            }
            db.Statuses.Update(user);
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
                Status user = await db.Statuses.FirstOrDefaultAsync(p => p.StatusId == id);
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
                Status user = await db.Statuses.FirstOrDefaultAsync(p => p.StatusId == id);
                user.IsDeleted = !user.IsDeleted;
                db.Statuses.Update(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
