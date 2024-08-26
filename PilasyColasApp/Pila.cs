using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasyColasApp
{
    public class Pila : IColeccion
    {
        Object[] elementos;
        public int contador { get; set; }

        public Pila(int tamaño)
        {
            elementos = new Object[tamaño];
            contador = 0;
        }
        public bool estaVacia()
        {
            return contador == 0;
        }
        public Object Extraer()
        {
            if (estaVacia())
            {
                return elementos[--contador];
            }
            contador--;
            object item = elementos[contador];
            elementos[contador] = null;
            return item;
        }

        public Object Primero()
        {
            if (estaVacia())
            {
                return elementos[contador];
            }
            return elementos[contador - 1];

        }

        public bool Añadir(object item)
        {
            if (contador >= elementos.Length)
            {
                return false;
            }
            elementos[contador] = item;
            contador++;
            return item;

        }

    }
}
