using GestionInventario.BBDD;
using GestionInventario.Entities;
using GestionInventario.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Pages
{
    public class CategoriasModel : PageModel
    {
        private readonly IRepository<Categoria> _categoriaRepository;

        public CategoriasModel(IRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public List<Categoria> Categorias { get; set; }

        public async Task OnGetAsync()
        {
            Categorias = await _categoriaRepository.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {

            bool success = await _categoriaRepository.DeleteAsync(id);
            if (success)
            {
                return RedirectToPage();
            }
            else {
                //TODO: Mostrar error "no se ha podido eliminar la Categoria"
                return RedirectToPage();
            }
            
        }
    }
}
