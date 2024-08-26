using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasyColasApp
{
    public interface IColeccion
    {
        bool estaVacia();
        object Extraer();
        object Primero();
        bool Añadir(Object obj);
    }
}
