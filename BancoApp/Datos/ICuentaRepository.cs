using BancoApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Datos
{
    public interface ICuentaRepository
    {
        List<Cuenta> GetAll();
        Cliente GetById(int id);
        bool Guardar(Cliente cliente);
        bool Borrar(int id);
    }
}
