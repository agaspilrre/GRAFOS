using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int numero = 1;

            CjtV<int> vertice = new CjtV<int>();

            vertice.Insertar(numero);
            vertice.Insertar(2);
            vertice.Insertar(3);
            vertice.Insertar(99);
            vertice.Insertar(4);
            
            vertice.Insertar(8122);
            vertice.Insertar(4);
           
            vertice.Borrar(99);


            Console.WriteLine(vertice.GetNumeroVertices());
            int[] enteros = vertice.ObtenerVertices();

            for(int i = 0; i < enteros.Length; i++)
            {
                Console.Write(enteros[i]+" ,");
            }
            */


            CjtV<int> vertice = new CjtV<int>();
            

            vertice.Insertar(99);
            vertice.Insertar(100);
            Console.WriteLine(vertice.Pertence(125));
            Console.WriteLine(vertice.ToString());


            string Anoth = "Anoth";
            string Arkania = "Arkania";
            string Bespin = "Bespin";
            string Chandrlla = "Chandrlla";
            string Cerea = "Cerea";
            string Drall = "Drall";
           


            Grafo<string> grafo = new Grafo<string>();
            grafo.InsertarArista(Anoth, Arkania, 7);
            grafo.InsertarArista(Anoth, Drall,3);
            grafo.InsertarArista(Arkania, Drall, 1);
            grafo.InsertarArista(Arkania, Bespin, 6);
            grafo.InsertarArista(Drall, Cerea, 8);
            grafo.InsertarArista(Bespin, Drall,3);
            grafo.InsertarArista(Bespin, Chandrlla, 2);
            grafo.InsertarArista(Cerea, Chandrlla, 8);
            
            grafo.InsertarVertice("Puertollano");
            Console.WriteLine(grafo.GetAristas());
            Console.WriteLine(grafo.GetVertices());

           List<string> prueba =  grafo.CaminoMasCorto(Anoth, Chandrlla);

            Console.Write("CAMINO MAS CORTO: ");

            for (int i = 0; i < prueba.Count; i++)
            {
                Console.Write(prueba[i]+  "-");
            }

            Console.WriteLine();

            List<string> prueba2 = grafo.CaminoMasCorto(Bespin, Bespin);

            Console.Write("CAMINO MAS CORTO: ");

            for (int i = 0; i < prueba2.Count; i++)
            {
                Console.Write(prueba2[i] + "-");
            }



            Console.WriteLine();

            List<string> prueba3 = grafo.CaminoMasCorto("Puertollano", Anoth);

            Console.Write("CAMINO MAS CORTO: ");

            for (int i = 0; i < prueba3.Count; i++)
            {
                
                    Console.Write(prueba3[i] + "-");
            }



              Console.WriteLine();


            Console.WriteLine(grafo.ToString());


        }
    }
}
