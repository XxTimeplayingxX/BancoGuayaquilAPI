namespace StoreDb.MODELS
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string Imagen { get; set; }
        public string Rating { get; set; }
        public int Categoria_id { get; set; }
    }
}
