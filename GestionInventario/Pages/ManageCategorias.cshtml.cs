using GestionInventario.BBDD;
using GestionInventario.Entities;
using GestionInventario.Interfaces;
using GestionInventario.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionInventario.Pages
{
    public class ManageCategoriasModel : PageModel
    {
        private readonly IRepository<Categoria> _categoriaRepository;

        public ManageCategoriasModel(IRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _categoriaRepository.AddAsync(Categoria);

            return RedirectToPage("./Categorias");
        }
    }
}
