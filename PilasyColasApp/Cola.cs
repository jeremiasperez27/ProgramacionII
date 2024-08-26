using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasyColasApp
{
    public class Cola : IColeccion
    {
        List<object> elementos;
        public Cola()
        {
            elementos = new List<object>();

        }
        public bool Añadir(object obj)
        {
            elementos.Add(obj);
            return true;
        }

        public bool estaVacia()
        {
            if (elementos.Count == 0) 
            { 
                return true; 
            } 
            else 
            { 
                return false; 
            }
        }

        public object Extraer()
        {
            elementos.Remove(0);
            return true;
        }

        public object Primero()
        {
            int tamaño = elementos.Count();
            return elementos[tamaño - 1];
        }
    }
}
