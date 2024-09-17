namespace Articulo_WebApi.Entities
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public float PrecioUnitario { get; set; }

        public Articulo()
        {
            Codigo = 0; 
            Nombre=string.Empty;
            PrecioUnitario = 0;
                
        }

        public Articulo(int codigo,string nombre,float precio)
        {
            Codigo=codigo;
            Nombre=nombre;
            PrecioUnitario=precio;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
