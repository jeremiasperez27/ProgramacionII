using Actividad1._5.Entidades;
using Actividad1._5.Repositorios.Contratos;
using Actividad1._5.Repositorios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad1._5.Servicios
{
    public class FacturacionManager
    {
        IFacturaRepository facturaRepository;
        IDetalleRepository detalleRepository;
        IFormaPagoRepository formaPagoRepository;
        IArticuloRepository articuloRepository;

        public FacturacionManager()
        {
            facturaRepository = new FacturaRepositoryADO();
            formaPagoRepository = new FormaPagoRepositoryADO();
            detalleRepository = new DetalleRepositoryADO();
            articuloRepository = new ArticuloRepositoryADO();
        }

        public bool Add(Factura oFactura)
        {
            return facturaRepository.Add(oFactura);
        }

        public List<FormaPago> GetAllFormasPago()
        {
            return formaPagoRepository.GetAll();
        }
        public List<Articulo> GetAllArticulos()
        {
            return articuloRepository.GetAll();
        }

        public List<Factura> GetAllFacturas()
        {
            return facturaRepository.GetAll();
        }

        public bool AddDetalle(DetalleFactura detalle)
        {
            return detalleRepository.Add(detalle);
        }
        public List<DetalleFactura> GetAllCuentas()
        {
            return detalleRepository.Get();
        }
    }
}
