using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Entities
{
	public class Producto
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La cantidad del producto es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
        public int Stock { get; set; }

        public int CategoriaId { get; set; }

        // Propiedades de navegación
        public Categoria Categoria { get; set; }
        public List<Transaccion> Transacciones { get; set; }
    }
}
