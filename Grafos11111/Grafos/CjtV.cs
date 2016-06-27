using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class CjtV<Informacion>
    {

        //atributos

        private Nodo<Informacion> conjunto;


        //metodos


        public void Borrar(Informacion e)
        {
         
            Nodo<Informacion> aux2 = conjunto.darSiguiente();//creo un nodo auxiliar que apunta al siguiente nodo
            Nodo<Informacion> aux = conjunto;//creo nodo auxiliar que apunto al primer nodo
            if (conjunto.darDato().Equals(e))
            {
                conjunto = conjunto.darSiguiente();//si el parametro e se encuentra en el primer nodo igualo conjunto con la direccion del siguiente nodo
            }

            else
            {//para los casos que el parametro no se encuentre en el primer nodo
                while (aux2 != null)
                {//mientras el siguiente nodo este vacio se metera u ejecutara el bucle asi recorreremos todos los nodos hasta el final
                    if (aux2.darDato().Equals(e))
                    {
                        aux.fijarSiguiente(aux2.darSiguiente());//si el siguiente nodo es igual al parametro e cogemos el nodo anterior  y fijamos la direccion del tercer nodo
                    }

                   
                    aux = aux2;//igualamos aux al siguiente nodo
                    aux2 = aux2.darSiguiente();//igualamos el siguiente nodo a su siguiente nodo
                        
                }
            }

            

        }


        //constructor
        public CjtV()
        {

            this.conjunto = null;//contruye un conjunto vacio
            
        }

        //constructor
        public CjtV(CjtV<Informacion> otroConjunto)
        {
            this.conjunto = otroConjunto.conjunto;//construye un conjunto de vertices con los datos de otro conjunto de vertices
        }


        public bool EsVacio()
        {
            return conjunto == null;//si el primer nodo esta vacio devuelve true si no devuelve false
        }

        public int GetNumeroVertices()
        {
            int numero = 0;//contador del numero de vertices o nodos que tenemos

            Nodo<Informacion> aux = conjunto;//variable auxiliar que apunta al primer nodo

            while (aux != null)
            {
                numero++;
                aux = aux.darSiguiente();//si el primer nodo contiene datos pasa al bucle incrementa la variable contador y da la direccion del siguiente nodo para comprobar si esta lleno, asi hasta que llega al ultimo nodo
            }

                return numero;//devuelve el numero de nodos que el metodo ha contado
        }

        public void Insertar(Informacion e)
        {

            //si la funcion pertenece me devuelve falso se mete dentro
            if(!Pertence(e))
            {
                //si el nodo esta vacio inserto el parametro e en el primer nodo
                if(EsVacio())
                {
                    conjunto = new Nodo<Informacion>(e);
                }

                //si el primer nodo ya tiene datos ejecuta el else
                else
                {
                    Nodo<Informacion> aux = conjunto;//creo auxiliar que apunta al primer nodo

                    while (aux.darSiguiente() != null)
                    {

                        aux = aux.darSiguiente();//compruebo el segundo nodo si contiene datos le asigno el siguiente nodo y asi hasta que llegue a uno que no contenga datos
                    }

                    aux.fijarSiguiente(new Nodo<Informacion>(e));//cuando llego al nodo que no contiene datos inserto informacion
                }
                
                

            }
        }

        public Informacion[] ObtenerVertices()
        {
            Nodo<Informacion> aux2 = conjunto;//auxiliar que apunta al primer nodo
            Informacion[] array = new Informacion[GetNumeroVertices()];//array que guarda los datos de los nodos
            int i = 0;//contador para ir incrementando las posiciones del array

            while (aux2 != null)
            {
                array[i] = aux2.darDato();//guardo el dato del nodo en el array si el nodo contiene dato
                i++;//incremento la posicion del array con i
                aux2 = aux2.darSiguiente();//paso a comprobar el siguiente nodo
            }

            return array;//devuelve el array con la informacion



        }

        public bool Pertence(Informacion e)
        {
            Nodo<Informacion> aux2 = conjunto;//creo un auxiliar que apunta al primer nodo
            bool confirmar = false;//para confirmar si el parametro recibido esta en la cadena de nodos

            while (aux2 != null)
            {
                if (aux2.darDato().Equals(e))
                {
                    confirmar = true;//si mientras recorremos los nodos encontramos alguno que sea igual al parametro recibido cambiamos la variable confirmar a true para decir que esa informacion ya esta contenida en alguno de los nodos
                    aux2 = null;
                }

                else
                    aux2 = aux2.darSiguiente();//le damos la direccion del siguiente nodo para que lo compruebe
            }

            return confirmar;//devolvemos el valor booleana que haya adquirido confirmar

        }

        public override string ToString()
        {
            string resultado = "{";

            Nodo<Informacion> aux2 = conjunto;//auxiliar que apunta al primer nodo

            while (aux2 != null)
            {
                resultado += aux2.darDato()+", ";//guardamos en la variable string los datos que contiene el nodo q recorremos
                aux2 = aux2.darSiguiente();//le pasamos la siguiente direccion para que compruebe el siguiente nodo asi hasta que recorra todos los nodos
            }
            if (resultado.Length > 1) 
                resultado = resultado.Substring(0, resultado.Length - 2);//quito a la cadena la coma y el espacio del ultimo dato siempre que la cadena de nodos sea mayor que uno
            return resultado+"}";//devuelvo el string
        }




    }
}
