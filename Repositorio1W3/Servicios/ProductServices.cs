using Repositorio1W3.Datos;
using Repositorio1W3.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio1W3.Servicios
{
    public class ProductServices
    {
        private ProductoRepositoryADO _repository;

        public ProductServices()
        {
            _repository = new ProductRepositoryADO();

        }
        public List<Producto> GetProductos()
        {
            return _repository.GetAll();
        }
    }
}
