using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class Nodo<Informacion>
    {
        private Nodo<Informacion> siguiente = null;
        private Informacion dato;

        public Nodo(Informacion dato)
        {
            this.dato = dato;
        }

        public Nodo(Informacion dato, Nodo<Informacion> siguiente)
        {
            this.dato = dato;
            this.siguiente = siguiente;
        }

        public Nodo<Informacion> darSiguiente()
        {
            return this.siguiente;
        }

        public Informacion darDato()
        {
            return this.dato;
        }

        public void fijarSiguiente(Nodo<Informacion> siguiente)
        {
            this.siguiente = siguiente;
        }
    }
}
