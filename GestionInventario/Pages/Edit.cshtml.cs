using GestionInventario.BBDD;
using GestionInventario.Entities;
using GestionInventario.Interfaces;
using GestionInventario.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Pages
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Producto> _productoRepository;
        private readonly IRepository<Categoria> _categoriaRepository;

        public EditModel(IRepository<Producto> productoRepository, IRepository<Categoria> categoriaRepository)
        {
            _productoRepository = productoRepository;
            _categoriaRepository = categoriaRepository;
        }

        [BindProperty]
        public ProductoViewModel Product { get; set; }

        public List<Categoria> Categorias { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Producto tmpproduct = await _productoRepository.GetByIdAsync(id);

            if (tmpproduct == null)
            {
                return NotFound();
            }

            Categorias = await _categoriaRepository.GetAllAsync();
            Product = new ProductoViewModel
            {
                Id = tmpproduct.Id,
                Nombre = tmpproduct.Nombre,
                Descripcion = tmpproduct.Descripcion,
                Stock = tmpproduct.Stock,
                Precio = tmpproduct.Precio,
                CategoriaId = tmpproduct.CategoriaId
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var producto = new Producto
            {
                Id = Product.Id,
                Nombre = Product.Nombre,
                Descripcion = Product.Descripcion,
                Stock = Product.Stock,
                Precio = Product.Precio,
                CategoriaId = Product.CategoriaId
            };

            await _productoRepository.UpdateAsync(producto);
            return RedirectToPage("./Index");
        }
    }
}
