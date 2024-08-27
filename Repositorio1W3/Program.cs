using Repositorio1W3.Dominio;
using Repositorio1W3.Servicios;

ProductServices oService = new ProductServices();

List<Producto> lp = oService.GetProductos();

if (lp.Count > 0)
{
    foreach (Producto p in lp)
    {
        Console.WriteLine(p);
    }
}
else
    Console.WriteLine("No hay productos");