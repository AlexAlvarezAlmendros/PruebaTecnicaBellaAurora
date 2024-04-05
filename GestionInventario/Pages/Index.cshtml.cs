using GestionInventario.BBDD;
using GestionInventario.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Pages
{
	public class IndexModel : PageModel
	{
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Producto> Productos { get; set; }

        public async Task OnGetAsync()
        {
            Productos = await _context.Productos.Include(p => p.Categoria).ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.Productos.FindAsync(id);
            if (product != null)
            {
                _context.Productos.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

    }
}