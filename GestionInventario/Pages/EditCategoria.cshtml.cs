using GestionInventario.BBDD;
using GestionInventario.Entities;
using GestionInventario.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Pages
{
    public class EditCategoriaModel : PageModel
    {
        private readonly IRepository<Categoria> _categoriaRepository;

        public EditCategoriaModel(IRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Categoria = await _categoriaRepository.GetByIdAsync(id);

            if (Categoria == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _categoriaRepository.UpdateAsync(Categoria);

            return RedirectToPage("./Categorias");
        }
    }
}
