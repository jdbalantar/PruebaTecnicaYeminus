namespace EncryptionSoftware.Application.Dto
{
    public class ProductDto
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<int> ListaDePrecios { get; set; }
        public string Imagen { get; set; }
        public bool ProductoParaLaVenta { get; set; }
        public int Iva { get; set; }
    }
}