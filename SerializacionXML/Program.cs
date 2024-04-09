using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace SerializacionXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            String valor = "";

            Console.WriteLine("1) Crear y serializar auto, 2) Leer auto");
            valor = Console.ReadLine();
            opcion = Convert.ToInt32(valor);

            if (opcion == 1)
            {
                //Creamos el objeto CAuto
                string modelo = "";
                double costo = 0;

                Console.WriteLine("Dame el modelo");
                modelo = Console.ReadLine();

                Console.WriteLine("Dame el costo");
                valor = Console.ReadLine();
                costo = Convert.ToDouble(valor);

                CAuto miAuto = new CAuto();
                miAuto.Modelo = modelo;
                miAuto.Costo = costo;

                Console.WriteLine("Auto a serializar");
                miAuto.MuestraInformacion();

                //Empezamos la serializacion
                Console.WriteLine("---SERIALIZAMOS---");

                //Sellecionamos el formateador
                XmlSerializer formateador = new XmlSerializer(typeof(CAuto));

                //Se crea el stream
                Stream miStream = new FileStream("Autos.aut", FileMode.Create, FileAccess.Write, FileShare.None);

                //Serializamos
                formateador.Serialize(miStream, miAuto);

                //Cerramos el stream
                miStream.Close();
            }

            if(opcion == 2)
            {
                //Deserealizamos el objeto
                Console.WriteLine("---DESEREALIZANDO---");

                //Seleccionamos el formateador
                XmlSerializer formateador = new XmlSerializer(typeof(CAuto));

                //Creamos el Stream
                Stream miStream = new FileStream("Autos.aut", FileMode.Open, FileAccess.Read, FileShare.None);

                //Deserializamos
                CAuto miAuto = (CAuto)formateador.Deserialize(miStream);

                //Cerramos el stream
                miStream.Close();

                //Usamos el objeto
                Console.WriteLine("El auto deserializado es: ");
                miAuto.MuestraInformacion();
            }
        }
    }
}
