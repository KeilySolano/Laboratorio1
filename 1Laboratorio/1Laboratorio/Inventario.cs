using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _1Laboratorio
{
    class Inventario
    {
        static string inventario = "Inventario.txt";
        static StreamReader Leer;
        static StreamWriter Escribir;

        public void GProducto()
        {
            int precio;
            precio = int.Parse(Console.ReadLine());
            Escribir.WriteLine(precio);           
            Escribir.Close();
        }
        
    }
}
