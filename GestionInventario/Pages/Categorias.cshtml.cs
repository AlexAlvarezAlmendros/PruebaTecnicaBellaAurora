using GestionInventario.BBDD;
using GestionInventario.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Pages
{
    public class CategoriasModel : PageModel
    {
        private readonly AppDbContext _context;

        public CategoriasModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Categoria> Categorias { get; set; }

        public async Task OnGetAsync()
        {
            Categorias = await _context.Categorias.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
