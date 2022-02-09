#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using billingOtt.Data;
using billingOtt.Models.Billing;

namespace billingOtt.Controllers
{
    public class BalancesController : Controller
    {
        private readonly BillingContext _context;

        public BalancesController(BillingContext context)
        {
            _context = context;
        }

        // GET: Balances
        public async Task<IActionResult> Index()
        {
            var billingContext = _context.Balances.Include(b => b.AccountNumberNavigation).Include(b => b.Service);
            return View(await billingContext.ToListAsync());
        }

        // GET: Balances/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balance = await _context.Balances
                .Include(b => b.AccountNumberNavigation)
                .Include(b => b.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balance == null)
            {
                return NotFound();
            }

            return View(balance);
        }

        // GET: Balances/Create
        public IActionResult Create()
        {
            ViewData["AccountNumber"] = new SelectList(_context.Accounts, "AccountNumber", "AccountNumber");
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
            return View();
        }

        // POST: Balances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServiceId,Amount,CreatedAt,UpdateAt,AccountNumber")] Balance balance)
        {
            if (ModelState.IsValid)
            {
                balance.Id = Guid.NewGuid();
                _context.Add(balance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountNumber"] = new SelectList(_context.Accounts, "AccountNumber", "AccountNumber", balance.AccountNumber);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", balance.ServiceId);
            return View(balance);
        }

        // GET: Balances/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balance = await _context.Balances.FindAsync(id);
            if (balance == null)
            {
                return NotFound();
            }
            ViewData["AccountNumber"] = new SelectList(_context.Accounts, "AccountNumber", "AccountNumber", balance.AccountNumber);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", balance.ServiceId);
            return View(balance);
        }

        // POST: Balances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ServiceId,Amount,CreatedAt,UpdateAt,AccountNumber")] Balance balance)
        {
            if (id != balance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(balance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BalanceExists(balance.Id))
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
            ViewData["AccountNumber"] = new SelectList(_context.Accounts, "AccountNumber", "AccountNumber", balance.AccountNumber);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", balance.ServiceId);
            return View(balance);
        }

        // GET: Balances/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balance = await _context.Balances
                .Include(b => b.AccountNumberNavigation)
                .Include(b => b.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balance == null)
            {
                return NotFound();
            }

            return View(balance);
        }

        // POST: Balances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var balance = await _context.Balances.FindAsync(id);
            _context.Balances.Remove(balance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BalanceExists(Guid id)
        {
            return _context.Balances.Any(e => e.Id == id);
        }
    }
}
