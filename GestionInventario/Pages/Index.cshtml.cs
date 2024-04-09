using GestionInventario.Entities;
using GestionInventario.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionInventario.Pages
{
	public class IndexModel : PageModel
	{
        private readonly IRepository<Producto> _productoRepository;

        public IndexModel(IRepository<Producto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public List<Producto> Productos { get; set; }

        public async Task OnGetAsync()
        {
            Productos = await _productoRepository.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            bool success = await _productoRepository.DeleteAsync(id);
            if (success)
            {
                return RedirectToPage();
            }
            else {
                //Todo: "No se ha podido eliminar el producto"
                return RedirectToPage();
            }
        }
    }
}