using GestionInventario.BBDD;
using GestionInventario.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Pages
{
    public class ManageInventoryModel : PageModel
    {
        private readonly AppDbContext _context;

        public ManageInventoryModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductoViewModel Product { get; set; }

        public List<Categoria> Categorias { get; set; }

        public void OnGet()
        {
            Categorias = _context.Categorias.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Vuelve a cargar las categorías para la vista en caso de falla de validación
                Categorias = await _context.Categorias.ToListAsync();
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

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
