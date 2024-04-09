using GestionInventario.BBDD;
using GestionInventario.Entities;
using GestionInventario.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Services
{
    public class ProductoRepository : IRepository<Producto>
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(Producto entity)
        {
            _context.Productos.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            else {
                return false;
            }
        }

        public async Task<List<Producto>> GetAllAsync() =>
            await _context.Productos.Include(p => p.Categoria).ToListAsync();

        public async Task<Producto> GetByIdAsync(int id) =>
            await _context.Productos.FindAsync(id);

        public async Task UpdateAsync(Producto entity)
        {
            _context.Attach(entity).State = EntityState.Modified;
            _context.Productos.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
