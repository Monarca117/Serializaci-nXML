using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializacionXML
{
    [Serializable]
    public class CAuto
    {
        private double costo;
        private String modelo;

        public double Costo { set { costo = value; } get { return costo; } }
        public String Modelo { set {  modelo = value; } get { return modelo; } }

        //Constructor sin parametros
        public CAuto() 
        {
            costo = 10000;
            modelo = "Vocho";
        }

        public void MuestraInformacion()
        {
            //Mostramos la informacion necesaria
            Console.WriteLine("Tu automovil {0}", modelo);
            Console.WriteLine("Costo {0}", costo);
            Console.WriteLine("------------------");
        }
    }
}
