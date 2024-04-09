using GestionInventario.BBDD;
using GestionInventario.Entities;
using GestionInventario.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Services
{
    public class CategoriaRepository : IRepository<Categoria>
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Categoria entity)
        {
            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return true;
            }
            else { 
                return false;
            }
        }

        public async Task<List<Categoria>> GetAllAsync() =>
            await _context.Categorias.ToListAsync();

        public async Task<Categoria> GetByIdAsync(int id) =>
            await _context.Categorias.FindAsync(id);

        public async Task UpdateAsync(Categoria entity)
        {
            _context.Attach(entity).State = EntityState.Modified;
            _context.Categorias.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
