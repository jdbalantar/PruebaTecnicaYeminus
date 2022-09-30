using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncryptionSoftware.Domain
{
    public class Productos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<int>? ListaDePrecios { get; set; }
        public string Imagen { get; set; }
        public bool ProductoParaLaVenta { get; set; }
        public int Iva { get; set; }
    }
}