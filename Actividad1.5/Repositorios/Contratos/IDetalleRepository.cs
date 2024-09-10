using Actividad1._5.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad1._5.Repositorios.Contratos
{
    public interface IDetalleRepository
    {
        bool Add(DetalleFactura detalle);
        List<DetalleFactura> Get();
        bool Update(DetalleFactura detalle);
    }
}
