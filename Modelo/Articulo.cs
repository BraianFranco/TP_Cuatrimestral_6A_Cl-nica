namespace Modelo
{

    public class Articulo
    {

        public int Id { get; set;}
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }
        public decimal Precio { get; set; }


        public override string ToString()
        {
            return this.Nombre;
        }
    }

}
