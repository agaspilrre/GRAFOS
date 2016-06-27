using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class Grafo<Informacion>
    {

        //atributos

        private CjtA<Informacion> aristas;
        private CjtV<Informacion> vertices;

        //metodos

        public void BorrarArista(Informacion v1, Informacion v2)
        {
            Arista<Informacion> aux = new Arista<Informacion>(v1, v2);//guardo en un auxiliar los parametros recibidos

            aristas.Borrar(aux);//llamo al metodo borrar de aristas y le paso la variable aux q contiene los parametros que hay que borrar

        }

        public void BorrarArista(Informacion v1, Informacion v2, double peso)
        {
            Arista<Informacion> aux = new Arista<Informacion>(v1, v2, peso);//igual que la anterior funcion solo que esta tambien puede recibir y borrar el peso
            aristas.Borrar(aux);
        }

        //metodo que no pide el ejercicio pero que creo para buscar aristas encontrarlas y guardarlas si las encuentra
        private Arista<Informacion> EncontrarArista(Informacion v1, Informacion v2, Arista<Informacion>[] arr)
        {
            Arista<Informacion> resultado = null;//guarda arista si la encuentra en el array de aristas obtenido del metodo 

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Destino.Equals(v2) && arr[i].Origen.Equals(v1))
                    resultado = arr[i];
            }

            return resultado;
        }

        public List<Informacion> CaminoMasCorto(Informacion origen, Informacion destino)
        {
            int numVertices = vertices.GetNumeroVertices();
            double[,] pesos = new double[numVertices, numVertices];
            int[,] caminos = new int[numVertices, numVertices];
            Arista<Informacion>[] arrayAris = aristas.obtenerAristas();
            Informacion[] arrayVerti = vertices.ObtenerVertices();
            Arista<Informacion> auxArista = null; 

            //algoritmo de floyd-Warshall
            //inicializamos la matriz de caminos y pesos

            for(int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++) {

                    if (i == j)
                    {
                        caminos[i, j] = -1;
                        pesos[i, j] = 0;
                    }
                    else
                    {
                        auxArista = EncontrarArista(arrayVerti[i], arrayVerti[j], arrayAris);
                        if (auxArista != null) //Si encuentro camino
                        {
                            pesos[i, j] = auxArista.Peso;
                            caminos[i, j] = i;
                        }
                        else
                        {
                            pesos[i, j] = Double.PositiveInfinity;
                            caminos[i, j] = -2;
                        }
                    }
                }
            }
            //algoritmo Floyd-Warshall
            double aux; 
            for (int k= 0; k< numVertices; k++)
            {
                for (int i = 0; i< numVertices; i++)
                {
                    for (int j= 0; j< numVertices; j++)
                    {
                       
                            aux = pesos[i, k] + pesos[k, j];

                            if (aux < pesos[i, j])
                            {
                                pesos[i, j] = aux;
                                caminos[i, j] = k;
                            }
                        
                    }
                }
            }




            //meto los datos del camino mas corto en una lista

            List<Informacion> lista = new List<Informacion>();
            int indiceOrigen = -1;
            int indiceDestino = -1;

            for (int i = 0; i< arrayVerti.Length; i++)
            {
                if (arrayVerti[i].Equals(destino))
                {
                    indiceDestino = i;
                }
                if (arrayVerti[i].Equals(origen))
                {
                    indiceOrigen = i;
                }

            }

            if (indiceOrigen == -1 || indiceDestino == -1)//si no hay camino devuelvo lista vacia
                return lista;


            lista.Add(arrayVerti[indiceOrigen]);
            bool encontrado = false;
            int siguiente = indiceOrigen;
            int anterior = 0; 
            while (!encontrado)
            {
                if (caminos[siguiente, indiceDestino] == siguiente)
                {
                    encontrado = true;
                    lista.Add(arrayVerti[indiceDestino]);
                }
                else if (caminos[siguiente, indiceDestino] == -2)
                {
                    encontrado = true;
                    lista.Clear(); //vaciar la lista 
                }
                else if (caminos[siguiente, indiceDestino] == -1)
                {
                    encontrado = true; 
                }
                else
                {
                    anterior = siguiente; 
                    siguiente = caminos[siguiente, indiceDestino];
                    if (caminos[anterior, siguiente] != anterior)
                        lista.Add(arrayVerti[caminos[anterior, siguiente]]);
                    lista.Add(arrayVerti[siguiente]);
                }


            }
            






            return lista;
        }

        public CjtA<Informacion> GetAristas()
        {
            return this.aristas;//devuelve las aristas del grafo
        }

        public CjtV<Informacion> GetVertices()
        {
            return this.vertices;//devuelve los vertices del grafo
        }

        //constructor

        public Grafo()
        {
            aristas = new CjtA<Informacion>();//contruye cjtu de aristas vacio
            vertices = new CjtV<Informacion>();//construye conjunto de vertices vacio
        }

        public void InsertarArista(Informacion v1, Informacion v2)
        {
            vertices.Insertar(v1);//llamo al metodo insertar de CjtV y le paso parametros
            vertices.Insertar(v2);
            aristas.Insertar(new Arista<Informacion>(v1, v2));//llamo al meotodo insertar de la clase CjtA y le paso los parametros
        }

        public void InsertarArista(Informacion v1,Informacion v2, double peso)
        {
            vertices.Insertar(v1);
            vertices.Insertar(v2);
            aristas.Insertar(new Arista<Informacion>(v1, v2, peso));//igual que el metodo anterior contemplando el peso
        }

        //metodos no descritos en pdf
        public void InsertarVertice(Informacion vertice)
        {
            vertices.Insertar(vertice);//llama al metodo insertar de conjunto de vertices pasandole la informacion que recibimos como parametro
        }

        public override string ToString()
        {
            string datos= "Vertices: "+vertices.ToString()+"\nAristas: "+aristas.ToString();//devuelvo los to string de las clases Cjtv y CjtA

            return datos;
        }


    }
}
