using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Entities
{
    public class ProductoViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La cantidad del producto es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La categoría del producto es obligatoria.")]
        public int CategoriaId { get; set; }
    }
}
