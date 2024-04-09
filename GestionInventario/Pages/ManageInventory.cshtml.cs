using GestionInventario.BBDD;
using GestionInventario.Entities;
using GestionInventario.Interfaces;
using GestionInventario.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Pages
{
    public class ManageInventoryModel : PageModel
    {
        private readonly IRepository<Producto> _productoRepository;
        private readonly IRepository<Categoria> _categoriaRepository;

        public ManageInventoryModel(IRepository<Producto> productoRepository, IRepository<Categoria> categoriaRepository)
        {
            _productoRepository = productoRepository;
            _categoriaRepository = categoriaRepository;
        }

        [BindProperty]
        public ProductoViewModel Product { get; set; }

        public List<Categoria> Categorias { get; set; }

        public async void OnGet()
        {
            Categorias = await _categoriaRepository.GetAllAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var producto = new Producto
            {
                Nombre = Product.Nombre,
                Descripcion = Product.Descripcion,
                Stock = Product.Stock,
                Precio = Product.Precio,
                CategoriaId = Product.CategoriaId
            };
            await _productoRepository.AddAsync(producto);

            return RedirectToPage("./Index");
        }
    }
}
