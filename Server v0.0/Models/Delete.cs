using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Server_v0._0.Models
{
    public class Delete:Controller
    {
        private readonly ApplicationContext _context;

        public Delete(ApplicationContext context)
        {
            _context = context;
        }
        public static string DelStatus(bool IsDeleted)
        {
            if (IsDeleted)
            {
                return "Restore";
            }
            else
            {
                return "Delete";
            }
        }

        public static string DelColor(bool IsDeleted)
        {
            if (IsDeleted)
            {
                return "background-color:#0a0a0a0a";
            }
            else
            {
                return "background-color:#fff";
            }
        }

        public async Task<IActionResult> AllDelete()
        {
            return View();
        }

        [HttpPost, ActionName("AllDelete")]
        public async Task<IActionResult> AllDeleteConfirmed()
        {
            await _context.Database.ExecuteSqlRawAsync("exec all_del");
            return RedirectToAction("Index","");
        }
    }
}
