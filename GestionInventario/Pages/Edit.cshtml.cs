using GestionInventario.BBDD;
using GestionInventario.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductoViewModel Product { get; set; }

        public List<Categoria> Categorias { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producto tmpproduct = await _context.Productos.FindAsync(id);

            if (tmpproduct == null)
            {
                return NotFound();
            }

            Categorias = _context.Categorias.ToList();
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

            _context.Attach(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Productos.Any(e => e.Id == producto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");

        }
    }
}
