using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Dominio
{
    public class Cuenta
    {
        public int Id { get; set; }
        public int Cbu { get; set; }
        public decimal Saldo { get; set; }
        public TipoCuenta tipoCuenta { get; set; }
        public DateTime UltimoMovimiento { get; set; }
        public int Cliente { get; set; }

    }
}
