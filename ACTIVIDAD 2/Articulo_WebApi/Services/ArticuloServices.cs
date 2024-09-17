using Articulo_WebApi.Data;
using Articulo_WebApi.Entities;

namespace Articulo_WebApi.Services
{
    public class ArticuloServices : IArticuloServices
    {
        private IArticuloRepository repository;
        public ArticuloServices()
        {
            repository = new ArticuloRepository();

        }
        public bool BorrarArticulo(int codigo)
        {
            return repository.BorrarArticulo(codigo);
        }

        public List<Articulo> ConsultarArticulos()
        {
            return repository.ObtenerArticulos();
        }

        public bool RegistrarArticulo(Articulo articulo)
        {
            return repository.AgregarEditarArticulo(articulo);
        }
    }
}
