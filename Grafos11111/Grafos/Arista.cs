using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class Arista<Informacion>
    {

        //atributos
        private Informacion destino;
        private Informacion origen;
        private double peso;

        //propiedades
        //propiedades que muestran los valores de destino origen y peso

        public Informacion Destino
        {
            get
            {
                return this.destino;
            }
        }

        public Informacion Origen
        {
            get
            {
                return this.origen;
            }
        }

        public double Peso
        {
            get
            {
                return this.peso;
            }
        }


        //metodos

        //constructor

        public Arista(Informacion origen,Informacion destino)
        {
            this.origen = origen;//origen y destino se igualan a los parametros obtenidos en el constructor
            this.destino = destino;
        }

        //constructor

        public Arista(Informacion origen, Informacion destino, double peso)
        {
            this.origen = origen;
            this.destino = destino;//igual que el anterior constructor igualando un parametro mas que es el peso para los casos en los que se quiera construir una arista con el dato peso
            this.peso = peso;

        }

        public override bool Equals(Object obj)
        {
            bool confirmar = false;
            Arista<Informacion> aux = obj as Arista<Informacion>;//variable de tipo arista guarda un null si el objeto recibido como parametro no es una arista en caso contrario guarda la arista q recibe como parametro
            if (aux != null)
            {
                confirmar = (aux.origen.Equals(this.origen)   && aux.destino.Equals(this.destino) && aux.peso == this.peso);//comparamos los parametros de la arista recibida origen destino y peso con los parametros de la arista actual
               //si son iguales confirmar adquiere el valor de true
            }
            return confirmar;//devuelve el valor true o false q haya sido almacenado en la variable confirmar
        }

       


        public override string ToString()
        {
            return "(" + origen.ToString() + "," + destino.ToString() + "," + peso + ")";//devuelve una cadena de texto con el origen destino y peso de la arista
        }



    }
}
