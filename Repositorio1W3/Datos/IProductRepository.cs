using Repositorio1W3.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio1W3.Datos
{
    public interface ProductoRepositoryADO
    {
        List<Producto> GetAll();
        Producto GetById(int id);
        bool Guardar(Producto producto);
        bool Borrar(int id);
    }
}
