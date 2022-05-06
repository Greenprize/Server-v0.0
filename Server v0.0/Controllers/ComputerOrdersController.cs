using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server_v0._0;
using Server_v0._0.Models;

namespace Server_v0._0.Controllers
{
    public class ComputerOrdersController : Controller
    {
        private readonly ApplicationContext _context;

        public ComputerOrdersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ComputerOrders
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ComputerOrders.Include(c => c.Computer).Include(c => c.Order);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ComputerOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerOrder = await _context.ComputerOrders
                .Include(c => c.Computer)
                .Include(c => c.Order)
                .FirstOrDefaultAsync(m => m.ComputerOrderId == id);
            if (computerOrder == null)
            {
                return NotFound();
            }

            return View(computerOrder);
        }

        // GET: ComputerOrders/Create
        public IActionResult Create()
        {
            ViewData["ComputerId"] = new SelectList(_context.Computers, "ComputerId", "ComputerId");
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            return View();
        }

        // POST: ComputerOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComputerOrderId,OrderId,ComputerId,Count")] ComputerOrder computerOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(computerOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComputerId"] = new SelectList(_context.Computers, "ComputerId", "ComputerId", computerOrder.ComputerId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", computerOrder.OrderId);
            return View(computerOrder);
        }

        // GET: ComputerOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerOrder = await _context.ComputerOrders.FindAsync(id);
            if (computerOrder == null)
            {
                return NotFound();
            }
            ViewData["ComputerId"] = new SelectList(_context.Computers, "ComputerId", "ComputerId", computerOrder.ComputerId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", computerOrder.OrderId);
            return View(computerOrder);
        }

        // POST: ComputerOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComputerOrderId,OrderId,ComputerId,Count")] ComputerOrder computerOrder)
        {
            if (id != computerOrder.ComputerOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computerOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerOrderExists(computerOrder.ComputerOrderId))
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
            ViewData["ComputerId"] = new SelectList(_context.Computers, "ComputerId", "ComputerId", computerOrder.ComputerId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", computerOrder.OrderId);
            return View(computerOrder);
        }

        // GET: ComputerOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerOrder = await _context.ComputerOrders
                .Include(c => c.Computer)
                .Include(c => c.Order)
                .FirstOrDefaultAsync(m => m.ComputerOrderId == id);
            if (computerOrder == null)
            {
                return NotFound();
            }

            return View(computerOrder);
        }

        // POST: ComputerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computerOrder = await _context.ComputerOrders.FindAsync(id);
            _context.ComputerOrders.Remove(computerOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputerOrderExists(int id)
        {
            return _context.ComputerOrders.Any(e => e.ComputerOrderId == id);
        }
    }
}
