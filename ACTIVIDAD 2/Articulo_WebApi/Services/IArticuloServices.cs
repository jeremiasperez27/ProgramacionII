using Articulo_WebApi.Entities;

namespace Articulo_WebApi.Services
{
    public interface IArticuloServices
    {
        List<Articulo> ConsultarArticulos();
        bool RegistrarArticulo(Articulo ariculo);
        bool BorrarArticulo(int codigo);
    }
}
