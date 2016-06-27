using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class CjtA<Informacion>
    {
        //atributos
        private Nodo<Arista<Informacion>> conjunto; 


        //metodos

        public void Borrar(Arista<Informacion> e)
        {
            Nodo<Arista<Informacion>> aux2 = conjunto.darSiguiente();//auxiliar q apunta el siguiente nodo de aristas
            Nodo<Arista<Informacion>> aux = conjunto;//apunta al primer nodo de aristas
            if (conjunto.darDato().Equals(e))
            {
                conjunto = conjunto.darSiguiente();//si el primer nodo es igual al parametro e igualo el primer nodo con la direccion del siguiente para asi eliminarlo
            }

            else
            {
                while (aux2 != null)
                {
                    //si el siguiente nodo contien datos pasa al bucle
                    if (aux2.darDato().Equals(e))
                    {
                        aux.fijarSiguiente(aux2.darSiguiente());//si el nodo siguiente es igual al parametro coge el nodo anterior y hace que apunte al tercer nodo quitando asi el nodo igual al parametro
                    }


                    aux = aux2;//le doy a aux la direccion del siguiente nodo
                    aux2 = aux2.darSiguiente();//le doy a al siguiente nodo la direccion de su siguiente

                }
            }


        }

        //constructor

        public CjtA()
        {
            conjunto = null;//crea conjunto vacio
        }

        public CjtA(CjtA<Informacion> otroConjunto)
        {
            this.conjunto = otroConjunto.conjunto;//crea un conjunto de vertices con los datos de otro conjunto de vertices que recibe como parametro
        }


        public bool EsVacio()
        {
            return conjunto == null; //si el primer nodo esta vacio devuelve un true si no un false
        }


        public int GetNumeroAristas()
        {
            int numero = 0;//contador de numero de aristas

            Nodo<Arista<Informacion>> aux = conjunto;//variable auxiliar que apunta al primer nodo

            while (aux != null)
            {
                numero++;//si el primer nodo contiene datos incrementa el contador
                aux = aux.darSiguiente();//le doy la direccion del siguiente nodo para que lo compruebe
            }

            return numero;//deuvelvo el numero de aristas que ha contado el metodo
        }

        public void Insertar(Arista<Informacion> e)
        {
            if (!Pertence(e))
            {
                if (EsVacio())
                {
                    conjunto = new Nodo<Arista<Informacion>>(e);//si el parametro e no pertenece al nodo y si el nodo primero esta vacio inserto prametro e en el primer nodo
                }

                else
                {
                    Nodo<Arista<Informacion>> aux = conjunto;//si el primer nodo tiene datos me creo un auxiliar que apunta al primer nodo

                    while (aux.darSiguiente() != null)
                    {

                        aux = aux.darSiguiente();//si el nodo siguiente tiene datos asigno su siguiente para comprobar hasta que llegue al nodo sin informacion
                    }

                    aux.fijarSiguiente(new Nodo<Arista<Informacion>>(e));//cuando llego al nodo vacio inserto el parametro e en ese nodo
                }



            }
        }

        public Arista<Informacion>[] obtenerAristas()
        {
            Nodo<Arista<Informacion>> aux2 = conjunto;//auxiliar que apunta al primer nodo
            Arista<Informacion>[] array = new Arista<Informacion>[GetNumeroAristas()];//array que va a guardar el conjutno de aristas o nodos
            int i = 0;//contador para incrementar las posiciones del array

            while (aux2 != null)
            {
                array[i] = aux2.darDato();//guardo el dato que contiene el nodo en el array
                i++;//incremento contador para incrementar posicion del array
                aux2 = aux2.darSiguiente();//le doy la direccion del siguiente nodo al auxiliar para que compruebe si tiene informacion
            }

            return array;//devuelvo el array

        }

        public bool Pertence(Arista<Informacion> e)
        {
            Nodo<Arista<Informacion>> aux2 = conjunto;//auxiliar que apunta al primer nodo
            bool confirmar = false;//booleano para comprobar si el parametro e ya pertenece al conjunto de aristas

            while (aux2 != null)
            {
                if (aux2.darDato().Equals(e))
                {
                    confirmar = true;//si el dato que contiene el nodo es igual al parametro e cambia el valor del booleano a true
                    aux2 = null;
                }

                else
                    aux2 = aux2.darSiguiente();//asigno nodo siguiente para comprobar
            }

            return confirmar;//devuelvo confirmar
        }

        public override string ToString()
        {
            string resultado = "{";

            Nodo<Arista<Informacion>> aux2 = conjunto;

            while (aux2 != null)
            {
                resultado += aux2.darDato() + ", ";//voy guardando los datos de cada nodo en el string
                aux2 = aux2.darSiguiente();//asigno siguiente nodo para comprobar
            }
            if (resultado.Length > 1)
                resultado = resultado.Substring(0, resultado.Length - 2);//quito el espacio y la coma del ultimo dato siempre que este sea mayor que uno
            return resultado + "}";//devuelve resultado
        }

    }
}
