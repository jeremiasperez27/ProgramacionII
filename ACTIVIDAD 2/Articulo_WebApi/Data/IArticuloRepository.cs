using Articulo_WebApi.Entities;

namespace Articulo_WebApi.Data
{
    public interface IArticuloRepository
    {
        List<Articulo> ObtenerArticulos();
        bool AgregarEditarArticulo(Articulo articulo);
        bool BorrarArticulo(int codigo);
    }
}
