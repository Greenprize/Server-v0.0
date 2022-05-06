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
    public class ReportOrdersController : Controller
    {
        private readonly ApplicationContext _context;

        public ReportOrdersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ReportOrders
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ReportOrders.Include(r => r.Order).Include(r => r.Report);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ReportOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportOrder = await _context.ReportOrders
                .Include(r => r.Order)
                .Include(r => r.Report)
                .FirstOrDefaultAsync(m => m.ReportOrderId == id);
            if (reportOrder == null)
            {
                return NotFound();
            }

            return View(reportOrder);
        }

        // GET: ReportOrders/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            ViewData["ReportId"] = new SelectList(_context.Reports, "ReportId", "ReportId");
            return View();
        }

        // POST: ReportOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportOrderId,OrderId,ReportId")] ReportOrder reportOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", reportOrder.OrderId);
            ViewData["ReportId"] = new SelectList(_context.Reports, "ReportId", "ReportId", reportOrder.ReportId);
            return View(reportOrder);
        }

        // GET: ReportOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportOrder = await _context.ReportOrders.FindAsync(id);
            if (reportOrder == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", reportOrder.OrderId);
            ViewData["ReportId"] = new SelectList(_context.Reports, "ReportId", "ReportId", reportOrder.ReportId);
            return View(reportOrder);
        }

        // POST: ReportOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportOrderId,OrderId,ReportId")] ReportOrder reportOrder)
        {
            if (id != reportOrder.ReportOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportOrderExists(reportOrder.ReportOrderId))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", reportOrder.OrderId);
            ViewData["ReportId"] = new SelectList(_context.Reports, "ReportId", "ReportId", reportOrder.ReportId);
            return View(reportOrder);
        }

        // GET: ReportOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportOrder = await _context.ReportOrders
                .Include(r => r.Order)
                .Include(r => r.Report)
                .FirstOrDefaultAsync(m => m.ReportOrderId == id);
            if (reportOrder == null)
            {
                return NotFound();
            }

            return View(reportOrder);
        }

        // POST: ReportOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportOrder = await _context.ReportOrders.FindAsync(id);
            _context.ReportOrders.Remove(reportOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportOrderExists(int id)
        {
            return _context.ReportOrders.Any(e => e.ReportOrderId == id);
        }
    }
}
