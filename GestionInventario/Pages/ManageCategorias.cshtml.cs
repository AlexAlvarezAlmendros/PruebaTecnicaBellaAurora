using GestionInventario.BBDD;
using GestionInventario.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionInventario.Pages
{
    public class ManageCategoriasModel : PageModel
    {
        private readonly AppDbContext _context;

        public ManageCategoriasModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categorias.Add(Categoria);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Categorias");
        }
    }
}
